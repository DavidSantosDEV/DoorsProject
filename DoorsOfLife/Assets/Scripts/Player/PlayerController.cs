using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    //public static PlayerController Instance { get; private set; } = null;

    //Other Components
    private PlayerMovement playerMovement;
    private PlayerWeapon playerWeapon;
    private PlayerAnimation playerAnimation;
    //private PlayerHealth playerHealthComponent;
    private PlayerHearts playerHeartsComponent;


    public PlayerMovement PlayerMovementComponent => playerMovement; // <<--
    public PlayerWeapon PlayerWeaponComponent => playerWeapon; //<<--
    public PlayerAnimation PlayerAnimationComponent =>playerAnimation;
    public PlayerHearts PlayerHeartsComponent => playerHeartsComponent;

    //Input
    [Header("Input Settings")]
    [SerializeField]
    private bool isXInverted = false;
    [SerializeField]
    private bool isYInverted = false;
    private Vector2 rawMovementInput;
    private Vector2 lastMovementInput;

    [Header("Player Interaction")]
    [SerializeField]
    private float offsetXInteract = 0, offsetYInteract = 0;
    [SerializeField]
    private float interactReach = 1f;
    [SerializeField]
    private LayerMask interactibleLayer;
    public InteractionData interactionData;
    private GameObject interactCanvas=null;
    [SerializeField]
    private Image imgPrompt=null;
    [SerializeField]
    private TextMeshProUGUI textPrompt=null;

    //Input components
    private PlayerControls myPlayerControls;
    private PlayerInput myInput;

    public PlayerInput PlayerInputComponent
    {
        get => myInput;
    }

    public bool inCutscene=false;

    private void OnDestroy()
    {
        interactionData.ResetData();
        //Instance = null;
        interactCanvas = null;
    }


    private string currentControlScheme; //Basically useless variable, delete when time available

    #region ActionMaps
    private string currentActionMap;
    private string actionMapGameplay = "Gameplay";
    private string actionMapMenu = "Menu";
    private string actionMapInteraction = "InInteraction";
    #endregion


    public Vector2 GetPositionVector2()
    {
        return transform.position;
    }
    public Vector3 GetPositionVector3()
    {
        return transform.position;
    }

    
    #region debugFunctions
    private void DebugGameOver()
    {
        if(Debug.isDebugBuild)
        GameManager.Instance.ShowGameOver();
    }

    private void debugCompletePuzzle()
    {
        if (!Debug.isDebugBuild) return;
        FindObjectOfType<PuzzleMasterOrder>()?.DebugFunc();
    }

    private void DebugFunc3()
    {
        if (!Debug.isDebugBuild) return;
        PuzzleChessMaster pz = FindObjectOfType<PuzzleChessMaster>();
        if (pz) pz.debugCompletePuzzle();
    }
    #endregion

    #region showingPrompt

    public void ShowPrompt(string text)
    {
        interactCanvas.SetActive(true);
        imgPrompt.sprite = UIManager.Instance?.getInteractSprite();
        textPrompt.text = text;
    }
    public void HidePrompt()
    {
        interactCanvas.SetActive(false);
    }

    #endregion

    public void Config()
    {
        #region Debug
        myPlayerControls.Gameplay.DebugL1.started += cntx => DebugGameOver();

        myPlayerControls.Gameplay.DebugR1.started += cntx => debugCompletePuzzle();

        myPlayerControls.Gameplay.Debug3.started += cntx => DebugFunc3();

        #endregion

        #region Gameplay
        myPlayerControls.Gameplay.Movement.performed += OnMovement;
        myPlayerControls.Gameplay.Movement.canceled += onStopMovement;

        myPlayerControls.Gameplay.Interact.started += OnInteract;

        myPlayerControls.Gameplay.Attack.started += OnAttack;

        myPlayerControls.Gameplay.Pause.started += cntx => GameManager.Instance.PauseToggle();
        #endregion

        #region Menu

        myPlayerControls.Menu.UnPause.started += cntx => GameManager.Instance.PauseToggle();

        #endregion

        #region Health Component
        if (playerHeartsComponent)
        {
            playerHeartsComponent.OnDamageTaken += OnDamageTaken;
            playerHeartsComponent.OnDeath += OnIsDead;
        }

        #endregion
        #region In Interaction
        myPlayerControls.InInteraction.ContinueInteract.started += ContinueInteract;

        #endregion

        //myInput.controlsChangedEvent.AddListener(OnControlsChanged);
    }

    private void Start()
    {
        Config();
    }

    void OnDamageTaken()
    {
        playerAnimation.PlayHitAnimation();
    }

    private void Update()
    {
        if (GameManager.Instance)
        {
            if (!inCutscene && !(GameManager.Instance.GameIsPaused))
            {
                CheckForInteractible();
            }
        }
        else
        {
            if (!inCutscene)
            {
                CheckForInteractible();
            }
        }

        OnMovement(myPlayerControls.Gameplay.Movement.ReadValue<Vector2>());


    }

    // Start is called before the first frame update
    private void Awake()
    {
        #region Getting Components
        playerMovement = GetComponent<PlayerMovement>();
        playerWeapon = GetComponent<PlayerWeapon>();
        playerAnimation = GetComponent<PlayerAnimation>();
        playerHeartsComponent = GetComponent<PlayerHearts>();

        myPlayerControls = new PlayerControls();
        myInput = GetComponent<PlayerInput>();

        interactCanvas = GetComponentInChildren<Canvas>().gameObject;
        #endregion

        myInput.actions = myPlayerControls.asset;

        myPlayerControls.Enable();

        //EnableGameplayControls();
        currentActionMap = actionMapGameplay; //Lets assume its always the gameplay starting

        myInput.actions.FindActionMap(actionMapInteraction).Disable();
        myInput.actions.FindActionMap(actionMapMenu).Disable();

        Debug.Log(currentActionMap);
        currentControlScheme = myInput.currentControlScheme;

        SceneManager.activeSceneChanged += SceneChanged;

        HidePrompt();
    }



    private void SceneChanged(Scene scene, Scene newScene)
    {
        if(this)
        transform.parent.position = GameObject.FindGameObjectWithTag("StartingPoint").transform.position;
        //Config();
    }

    private void UpdateLastMovement()
    {
        if (rawMovementInput.normalized != Vector2.zero)
        {
            lastMovementInput = rawMovementInput.normalized;
            //Debug.Log(lastMovementInput);
            lastMovementInput = new Vector2(Mathf.RoundToInt(lastMovementInput.x), Mathf.RoundToInt(lastMovementInput.y));

            if (lastMovementInput.x == lastMovementInput.y || lastMovementInput.x == -lastMovementInput.y)
            {
                lastMovementInput = lastMovementInput / 1.5f;
            } //The original idea with this piece of code was that the sides should have been 0.5 instead of 1 but thinking it further this is the right way, making it the trignometric circle
        }
    }

    private bool canMove = true;
    public void StopMovement()
    {
        rawMovementInput = Vector2.zero;
        UpdateMovement();
        canMove = false;
    }

    public void EnableMovement()
    {
        canMove = true;
    }

    private void UpdateMovement()
    {
        if (canMove)
        {
            playerMovement.UpdateMovementData(rawMovementInput.normalized);

            playerAnimation.UpdateMovementAnimation(rawMovementInput);

            UpdateLastMovement();
        }

    }

    private void CheckForInteractible()
    {
        Vector3 startpos = transform.position + new Vector3(offsetXInteract, offsetYInteract);
        RaycastHit2D _Hits;
        _Hits = Physics2D.Raycast(startpos, lastMovementInput,interactReach,interactibleLayer);

        

        if (_Hits && _Hits.transform.CompareTag("Interactible"))
        {
            IInteractibleBase interactible = _Hits.transform.GetComponent<IInteractibleBase>();
            if (interactible)
            {
                if (interactionData.IsEmpty())
                {
                    interactionData.Interactible = interactible;
                    ShowPrompt(interactible.InteractionText);
                    Debug.DrawRay(startpos, lastMovementInput * interactReach, Color.green);
                }
                else
                {
                    if (!interactionData.IsSameInteractible(interactible))
                    {
                        interactionData.Interactible = interactible;
                        ShowPrompt(interactible.InteractionText);
                        Debug.DrawRay(startpos, lastMovementInput * interactReach, Color.green);
                    }
                    else
                    {
                        Debug.DrawRay(startpos, lastMovementInput * interactReach, Color.green);
                        return;
                    }
                }
            }
        }
        else
        {
            Debug.DrawRay(startpos, lastMovementInput * interactReach, Color.red);
            HidePrompt();
            interactionData.ResetData();
        }
    }

    //Events

    public Vector2 ReturnFacingDirection()
    {
        return lastMovementInput;
    }

#region Events
    private void OnInteract(InputAction.CallbackContext context)
    {
        if (!interactionData.IsEmpty())
        {
            Debug.Log("Interacted");
            interactionData.Interact();
            HidePrompt();
        }
        
    }

    public void IsInteracting(InteractionType type)
    {
        switch (type)
        {
            case InteractionType.DialogInteraction:
                EnableDialogControls();
                break;

        }
    }

    public void StoppedInteracting()
    {
        interactionData.ResetData();
        EnableGameplayControls();
    }
    public void OnMovement(InputAction.CallbackContext cont)
    {
        Vector2 context = cont.ReadValue<Vector2>();
        rawMovementInput = new Vector2(isXInverted ? -context.x : context.x,
            isYInverted ? -context.y : context.y);
        UpdateMovement();
    }

    private void OnMovement(Vector2 mov)
    {
        rawMovementInput = new Vector2(isXInverted ? -mov.x : mov.x,
            isYInverted ? -mov.y : mov.y);
        UpdateMovement();
    }

    private void onStopMovement(InputAction.CallbackContext context)
    {
        rawMovementInput = Vector2.zero;
        UpdateMovement();
    }

    public bool canAttack = true;

    private void OnAttack(InputAction.CallbackContext context)
    {
        if (canAttack)
        {
            playerWeapon.PlayerAttack(lastMovementInput.normalized);
            playerAnimation.PlayAttackAnimation();
            canAttack = false;
        }
    }


    private void ContinueInteract(InputAction.CallbackContext context)
    {
        interactionData.ContinueInteract();
    }

    public void OnIsDead()
    {
        playerAnimation.PlayDeathAnimation();
        EnableMenuControls();
    }

    #endregion

    
#region UIRelated

    #endregion
    //Switching Control types

    public void EnableGameplayControls()
    {
        myInput.SwitchCurrentActionMap(actionMapGameplay);
        if (currentActionMap != "")
        {
            try
            {
                myInput.actions.FindActionMap(currentActionMap).Disable();
            }
            catch (Exception ex)
            {
                Debug.Log(ex);
            }
        }
        currentActionMap = actionMapGameplay;
    }

    public void EnableMenuControls() 
    {
        myInput.SwitchCurrentActionMap(actionMapMenu);
        myInput.actions.FindActionMap(currentActionMap).Disable();
        currentActionMap = actionMapMenu;
    }

    public void EnableDialogControls()
    {
        myInput.SwitchCurrentActionMap(actionMapInteraction);
        myInput.actions.FindActionMap(currentActionMap).Disable();
        currentActionMap = actionMapInteraction;
    }


    public void Revive()
    {
        EnableGameplayControls();
        playerHeartsComponent.ResetComponent();
    }

    private void OnDrawGizmos()
    {
        Vector3 startpos = transform.position + new Vector3(offsetXInteract, offsetYInteract);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(startpos, lastMovementInput * interactReach);
    }
}

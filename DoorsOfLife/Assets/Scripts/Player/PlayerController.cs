using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; } = null;

    //Other Components
    public PlayerMovement playerMovement;
    public PlayerWeapon playerWeapon;
    public PlayerAnimation playerAnimation;
    public PlayerHealth playerHealthComponent;

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
    private float interactReach = 1f;
    [SerializeField]
    private LayerMask interactibleLayer;
    public InteractionData interactionData;
    //Input components


    private PlayerControls myPlayerControls;
    public PlayerInput myInput;

    private string currentControlScheme;

    #region Interaction

    [SerializeField]
    private float speedInteractCode=2;
    [SerializeField]
    private float offsetXInteract = 0, offsetYInteract = 0;
    //private bool isInteracting=false;

    #endregion


    #region ActionMaps
    private string currentActionMap;
    private string actionMapGameplay = "Gameplay";
    private string actionMapMenu = "Menu";
    private string actionMapInteraction = "InInteraction";
    #endregion


    public Vector2 GetPosition()
    {
        return transform.position;
    }

    private void DebugGameOver()
    {
        if(Debug.isDebugBuild) //Just in case i forget
        GameManager.Instance.ShowGameOver();
    }

    // Start is called before the first frame update
    private void Awake()
    {

        #region Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }

        #endregion

        #region Getting Components
        playerMovement = GetComponent<PlayerMovement>();
        playerWeapon = GetComponent<PlayerWeapon>();
        playerAnimation = GetComponent<PlayerAnimation>();
        playerHealthComponent = GetComponent<PlayerHealth>();

        myPlayerControls = new PlayerControls();
        myInput = GetComponent<PlayerInput>();
        #endregion

        myInput.actions = myPlayerControls.asset;

        #region Debug
        myPlayerControls.Gameplay.DebugL1.started += cntx => DebugGameOver();

        myPlayerControls.Gameplay.DebugR1.started += cntx => GameManager.Instance.ResetPieces();
        #endregion

        #region Gameplay
        myPlayerControls.Gameplay.Movement.performed += cntx => OnMovement(cntx.ReadValue<Vector2>());
        myPlayerControls.Gameplay.Movement.canceled += cntx => onStopMovement();

        myPlayerControls.Gameplay.Interact.started += cntx => OnInteract();

        myPlayerControls.Gameplay.Attack.started += cntx => OnAttack();

        myPlayerControls.Gameplay.Pause.started += cntx => GameManager.Instance.PauseToggle();
        #endregion

        #region Menu

        myPlayerControls.Menu.UnPause.started += cntx => GameManager.Instance.PauseToggle();

        #endregion

        #region In Interaction
        myPlayerControls.InInteraction.ContinueInteract.started += cntx => ContinueInteract();

        #endregion

        myPlayerControls.Enable();


        currentActionMap = actionMapGameplay; //Lets assume its always the gameplay starting

        myInput.actions.FindActionMap(actionMapInteraction).Disable();
        myInput.actions.FindActionMap(actionMapMenu).Disable();

        Debug.Log(currentActionMap);
        currentControlScheme = myInput.currentControlScheme;



        //Other components
        


    }

    private void Start()
    {
        StartCoroutine(nameof(RoutineCheckInteractible));
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateMovement();
        UpdateLastMovement();
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

    private void UpdateMovement()
    {
        playerMovement.UpdateMovementData(rawMovementInput);

        playerAnimation.UpdateMovementAnimation(rawMovementInput);
    }

    private IEnumerator RoutineCheckInteractible() //So this is in a couroutine so that its not as heavy
    {
        while (enabled)
        {
            CheckForInteractible();
            yield return new WaitForSeconds(1/speedInteractCode);
        }
    }

    //IInteractibleBase interactible; 
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
                    Debug.DrawRay(startpos, lastMovementInput * interactReach, Color.green, 0.2f);
                }
                else
                {
                    if (!interactionData.IsSameInteractible(interactible))
                    {
                        interactionData.Interactible = interactible;
                        Debug.DrawRay(startpos, lastMovementInput * interactReach, Color.green, 0.2f);
                    }
                    else
                    {
                        Debug.DrawRay(startpos, lastMovementInput * interactReach, Color.blue, 0.2f);
                        return;
                    }
                }
            }
        }
        else
        {
            Debug.DrawRay(startpos, lastMovementInput * interactReach, Color.red, 0.2f);
            interactionData.ResetData();
        }
    }

    //Events

    public Vector2 ReturnFacingDir()
    {
        return lastMovementInput;
    }

#region Events
    private void OnInteract()
    {
        if (!interactionData.IsEmpty())
        {
            interactionData.Interact();        
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
    public void OnMovement(Vector2 context)
    {
        Vector2 tempValue = context;
        rawMovementInput = new Vector2(isXInverted ? -tempValue.x : tempValue.x,
            isYInverted ? -tempValue.y : tempValue.y);
    }

    private void onStopMovement()
    {
        rawMovementInput = Vector2.zero;
    }

    private void OnAttack()
    {
        playerWeapon.PlayerAttack(lastMovementInput);
        playerAnimation.PlayAttackAnimation();
    }


    private void ContinueInteract()
    {
        interactionData.ContinueInteract();
    }

    public void OnIsDead()
    {
        enabled = false;
    }

    public void ResetDeath()
    {

    }

    #endregion

    
#region UIRelated
    public void OnControlsChanged()
    {
        if (currentControlScheme != myInput.currentControlScheme)
        {
            Debug.Log(myInput.devices[0].ToString());
            currentControlScheme = myInput.currentControlScheme;
            Debug.Log(currentControlScheme);

            if(UIManager.Instance!=null) UIManager.Instance.PromptsChange();
            if (GamepadRumbler.Instance != null) GamepadRumbler.Instance.SetGamepad();
        }
    }

    #endregion
    //Switching Control types

    public void EnableGameplayControls()
    {
        myInput.SwitchCurrentActionMap(actionMapGameplay);
        myInput.actions.FindActionMap(currentActionMap).Disable();
        currentActionMap = actionMapGameplay;
    }

    public void EnableMenuControls() //finish after
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
}

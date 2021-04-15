using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine;

public class PlayerMenuController : MonoBehaviour
{
    public static PlayerMenuController Instance { get; private set; } = null;



    private PlayerControls myPlayerControls;
    public PlayerInput myInput;
    public InputSystemUIInputModule uiInput;

    private string currentControlScheme;

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }


        myPlayerControls = new PlayerControls();
        currentControlScheme = myInput.currentControlScheme;
        myPlayerControls.Enable();
    }

    public void OnControlsChanged()
    {
        if (currentControlScheme != myInput.currentControlScheme)
        {
            Debug.Log(myInput.devices[0].ToString());
            currentControlScheme = myInput.currentControlScheme;
            Debug.Log(currentControlScheme);

            if (UIManager.Instance != null) UIManager.Instance.PromptsChange();
            if (GamepadRumbler.Instance != null) GamepadRumbler.Instance.SetGamepad();

            //playerVisuals.UpdatePlayerVisuals(); //Line of code to update ui when you make it
            //RemoveAllBindingOverrides();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class NewPlayerController : MonoBehaviour
{
    PlayerInput myInput;
    PlayerControls myControls;

    PlayerMovement playerMovement;
    PlayerWeapon playerWeapon;
    PlayerAnimation playerAnimation;
    PlayerHearts playerHearts;

    private void Awake()
    {
        #region Getting Components

        playerMovement = GetComponent<PlayerMovement>();
        playerWeapon = GetComponent<PlayerWeapon>();
        playerAnimation = GetComponent<PlayerAnimation>();
        playerHearts = GetComponent<PlayerHearts>();

        myInput = GetComponent<PlayerInput>();

        #endregion

        myControls = new PlayerControls();
        myControls.Enable();
    }

    private void Update()
    {
        
    }
}

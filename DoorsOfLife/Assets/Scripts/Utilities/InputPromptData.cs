using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Input Prompt Data", menuName = "InteractionSystem/InputPromptData")]
public class InputPromptData : ScriptableObject
{
    [Header("Playstation")]
    public Sprite southButtonPlayStation;
    public Sprite northButtonPlayStation;
    public Sprite westButtonPlayStation;
    public Sprite eastButtonPlayStation;

    [Header("Microsoft")]
    public Sprite southButtonMicrosoft;
    public Sprite northButtonMicrosoft;
    public Sprite westButtonMicrosoft;
    public Sprite eastButtonMicrosoft;

    [Header("Shared Gamepad Features")]
    public Sprite R1Trigger;
    public Sprite R2Trigger;
    public Sprite L1Trigger;
    public Sprite L2Trigger;
    public Sprite DPADFull;
    public Sprite LAnalog;
    public Sprite RAnalog;


    [Header("Keyboard and Mouse")]
    public Sprite KeyInteract;

    public Sprite GetButtonInteractSprite()
    {
        PlayerController p = GameManager.Instance.GetPlayer();
        string var="";
        if (/*GameManager.Instance.GetPlayer()*/p !=null)//PlayerController.Instance
        {
            var = GameManager.Instance.GetPlayer().PlayerInputComponent.devices[0].name;// PlayerController.Instance.GetMyInput().devices[0].name;//myInput.devices[0].name;
        }
        else if(PlayerMenuController.Instance!=null)
        {
            var = PlayerMenuController.Instance.myInput.devices[0].name;   
        }
        switch (var)
        {
            case "DualShock4GamepadHID:/DualShock4GamepadHID": //PS        
            case "DualShock4GamepadHID":
                return southButtonPlayStation;

            case "Keyboard":
            case "Keyboard:/Keyboard":
                return KeyInteract;

            default:
                return southButtonMicrosoft; //Not like I have a MS controller so here it is the lazy way
        }
    }
}

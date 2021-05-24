// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/Input/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""620ad9ef-1e6b-40dd-bdb7-81ea4889998a"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""563a77a6-a35b-4b61-b6e7-017eb7abead6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""2334fd1d-f642-4b69-a150-5e02cb1e5279"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""2fb44476-9141-4b40-a9c4-b4943e8fbeaa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DebugR1"",
                    ""type"": ""Button"",
                    ""id"": ""6863634a-ba2c-4d9a-b47b-84fdb9d17e13"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DebugL1"",
                    ""type"": ""Button"",
                    ""id"": ""4a3035a1-4006-4c74-bdac-171178698baf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""93954da3-7f99-41e6-bfd0-e98ef32641be"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Debug3"",
                    ""type"": ""Button"",
                    ""id"": ""d6348bd6-e67b-4317-8a09-1c0a1fc351e2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Debug4"",
                    ""type"": ""Button"",
                    ""id"": ""ea282169-bc8e-4be2-a0d6-4cfc11f8f4d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Debug5"",
                    ""type"": ""Button"",
                    ""id"": ""35cf8cce-79f1-48a7-af45-410a60f778b4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5464dfd8-0521-4e18-bf4a-c5fe7aa2f0e4"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""caab353c-4d0e-4b13-95ba-8e72feb73c26"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0213cdc9-6c6a-4fa1-a1a4-6ade8b0dc505"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6dcfe702-c784-4215-9888-ddf6ec555c76"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0687fa27-1bf2-40e4-b594-2fee680784eb"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""59419ff7-8e9e-472e-a9d9-ffb5c03b762c"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1673a2bc-bb8b-4246-9c16-d7bae4718d9e"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""360711d6-ac98-458d-beb9-67301bf6616f"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6e06db7e-3fc3-40a8-b8bb-75d7582381b3"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ebe5c2b0-b1dc-4762-acaa-2c52547d6801"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""46df9167-db71-465e-92df-eb6ac509b052"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be20a34d-b86c-40af-b77b-fe9a3b686800"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DebugR1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""131dadf6-461b-4b44-bd00-e38ce33efd79"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DebugR1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4047539e-387b-4e01-976d-86966c40095a"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DebugL1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb895eac-a2d9-4c36-a5ce-04f8059e5781"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DebugL1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf8c94d8-26dc-4cce-9ad3-076921ebb7c4"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1410b746-20af-44f6-8ddf-aa8326f5d765"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""22779c26-da48-4efc-9814-afab54b22aad"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Debug3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""91e8585d-08b9-4e35-b67f-d649eef1577b"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Debug4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ead79f7e-28ba-4e69-b06b-4671178df2db"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Debug4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2009fd90-ac6f-45bb-997d-858b56b9cefb"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Debug5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c10e4cd4-4c0b-4a8a-8177-ca11cc1457b7"",
                    ""path"": ""<Keyboard>/numpad7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Debug5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""7802725c-768f-434c-bd7e-7be6b4c31166"",
            ""actions"": [
                {
                    ""name"": ""MenuNavigation"",
                    ""type"": ""Value"",
                    ""id"": ""a8ac5b4f-a230-45d1-8286-6c029d256f5c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""abb31226-f199-4099-a555-4a2e2114ac14"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UnPause"",
                    ""type"": ""Button"",
                    ""id"": ""e432e1fa-5644-400e-ba7a-ff3d8038923e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseClick"",
                    ""type"": ""Button"",
                    ""id"": ""c19229b7-5e29-458d-a8d5-9d87350b3e95"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Point"",
                    ""type"": ""PassThrough"",
                    ""id"": ""133cfc51-3cb0-464a-b187-424aefae35a3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7d6986e6-9621-406e-936d-262ae1c4105f"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuNavigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""483cf5ed-030a-4067-924f-dcde7a22035d"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuNavigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""7833dfee-e66d-49b9-8a1a-cbc71f0498a5"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MenuNavigation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1858a1cc-a119-415f-bd05-b46d3ecd1a78"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""MenuNavigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""aa4c6d9f-ab31-4692-a1e4-eec70e8b690c"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""MenuNavigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""79ddbec7-4ef5-4cec-be5b-1d5612d38493"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""MenuNavigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ea927013-5275-46ec-bd8f-a6f18c297c32"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""MenuNavigation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0d0439bd-c739-4ce7-86d7-2267c1e2e219"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6a8180a1-d847-4fdc-bffd-cbbad27fe5f5"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""408a1311-43ac-4bb0-ae87-dc0ab52d1862"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f7b2bdd3-4fdd-4e3e-a3b1-2f2d90dcac83"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UnPause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8aa8875c-8c6f-4de6-9aa9-76021eaa03fa"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UnPause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89ea6ab4-2995-4b9b-a8fc-9719a8c8d1c2"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""UnPause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""65b6885e-4b02-4af3-a3af-c14ceff1b680"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""MouseClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ba9feda2-b14f-4da7-9da7-7c431c638bb6"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""InInteraction"",
            ""id"": ""31975c74-409d-45ec-9a66-42c13e18a3d7"",
            ""actions"": [
                {
                    ""name"": ""ContinueInteract"",
                    ""type"": ""Button"",
                    ""id"": ""e1cb5ab8-16a1-40e6-a465-316a74fe06e7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b1dd8eaa-c5ee-44bb-b2f1-68d66f11a1cc"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ContinueInteract"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20e4ebea-34eb-4d64-82ff-d065611d6d59"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""ContinueInteract"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Prompt"",
            ""id"": ""3976c447-8f02-4754-b926-22ef6c5f836b"",
            ""actions"": [
                {
                    ""name"": ""MovePrompt"",
                    ""type"": ""Value"",
                    ""id"": ""51f7e310-1334-453c-af25-53f1b6bd254f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ConfirmPrompt"",
                    ""type"": ""Button"",
                    ""id"": ""8ee0b189-00b0-4000-a25f-c1eddcdb26c3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""5375cc9a-432a-414d-b03d-7a040fba799f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovePrompt"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1946b0dd-dfa6-4bcd-b315-d6cd69b8aeef"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovePrompt"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a9d38b98-fb89-4a3c-b75b-a62079a6766a"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovePrompt"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7f2817c9-1200-437b-96a5-38129808955b"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovePrompt"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e77b3031-d00d-4ebf-8cf8-ff493dd79a85"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovePrompt"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0f826b65-a0da-4631-9e88-183c09199f04"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MovePrompt"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1eab5a4e-58d8-46f1-ab28-3feaf4f17a22"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ConfirmPrompt"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard and Mouse"",
            ""bindingGroup"": ""Keyboard and Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
        m_Gameplay_Interact = m_Gameplay.FindAction("Interact", throwIfNotFound: true);
        m_Gameplay_Attack = m_Gameplay.FindAction("Attack", throwIfNotFound: true);
        m_Gameplay_DebugR1 = m_Gameplay.FindAction("DebugR1", throwIfNotFound: true);
        m_Gameplay_DebugL1 = m_Gameplay.FindAction("DebugL1", throwIfNotFound: true);
        m_Gameplay_Pause = m_Gameplay.FindAction("Pause", throwIfNotFound: true);
        m_Gameplay_Debug3 = m_Gameplay.FindAction("Debug3", throwIfNotFound: true);
        m_Gameplay_Debug4 = m_Gameplay.FindAction("Debug4", throwIfNotFound: true);
        m_Gameplay_Debug5 = m_Gameplay.FindAction("Debug5", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_MenuNavigation = m_Menu.FindAction("MenuNavigation", throwIfNotFound: true);
        m_Menu_Confirm = m_Menu.FindAction("Confirm", throwIfNotFound: true);
        m_Menu_UnPause = m_Menu.FindAction("UnPause", throwIfNotFound: true);
        m_Menu_MouseClick = m_Menu.FindAction("MouseClick", throwIfNotFound: true);
        m_Menu_Point = m_Menu.FindAction("Point", throwIfNotFound: true);
        // InInteraction
        m_InInteraction = asset.FindActionMap("InInteraction", throwIfNotFound: true);
        m_InInteraction_ContinueInteract = m_InInteraction.FindAction("ContinueInteract", throwIfNotFound: true);
        // Prompt
        m_Prompt = asset.FindActionMap("Prompt", throwIfNotFound: true);
        m_Prompt_MovePrompt = m_Prompt.FindAction("MovePrompt", throwIfNotFound: true);
        m_Prompt_ConfirmPrompt = m_Prompt.FindAction("ConfirmPrompt", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Movement;
    private readonly InputAction m_Gameplay_Interact;
    private readonly InputAction m_Gameplay_Attack;
    private readonly InputAction m_Gameplay_DebugR1;
    private readonly InputAction m_Gameplay_DebugL1;
    private readonly InputAction m_Gameplay_Pause;
    private readonly InputAction m_Gameplay_Debug3;
    private readonly InputAction m_Gameplay_Debug4;
    private readonly InputAction m_Gameplay_Debug5;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputAction @Interact => m_Wrapper.m_Gameplay_Interact;
        public InputAction @Attack => m_Wrapper.m_Gameplay_Attack;
        public InputAction @DebugR1 => m_Wrapper.m_Gameplay_DebugR1;
        public InputAction @DebugL1 => m_Wrapper.m_Gameplay_DebugL1;
        public InputAction @Pause => m_Wrapper.m_Gameplay_Pause;
        public InputAction @Debug3 => m_Wrapper.m_Gameplay_Debug3;
        public InputAction @Debug4 => m_Wrapper.m_Gameplay_Debug4;
        public InputAction @Debug5 => m_Wrapper.m_Gameplay_Debug5;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Interact.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Attack.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttack;
                @DebugR1.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDebugR1;
                @DebugR1.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDebugR1;
                @DebugR1.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDebugR1;
                @DebugL1.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDebugL1;
                @DebugL1.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDebugL1;
                @DebugL1.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDebugL1;
                @Pause.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Debug3.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDebug3;
                @Debug3.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDebug3;
                @Debug3.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDebug3;
                @Debug4.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDebug4;
                @Debug4.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDebug4;
                @Debug4.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDebug4;
                @Debug5.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDebug5;
                @Debug5.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDebug5;
                @Debug5.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDebug5;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @DebugR1.started += instance.OnDebugR1;
                @DebugR1.performed += instance.OnDebugR1;
                @DebugR1.canceled += instance.OnDebugR1;
                @DebugL1.started += instance.OnDebugL1;
                @DebugL1.performed += instance.OnDebugL1;
                @DebugL1.canceled += instance.OnDebugL1;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Debug3.started += instance.OnDebug3;
                @Debug3.performed += instance.OnDebug3;
                @Debug3.canceled += instance.OnDebug3;
                @Debug4.started += instance.OnDebug4;
                @Debug4.performed += instance.OnDebug4;
                @Debug4.canceled += instance.OnDebug4;
                @Debug5.started += instance.OnDebug5;
                @Debug5.performed += instance.OnDebug5;
                @Debug5.canceled += instance.OnDebug5;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_MenuNavigation;
    private readonly InputAction m_Menu_Confirm;
    private readonly InputAction m_Menu_UnPause;
    private readonly InputAction m_Menu_MouseClick;
    private readonly InputAction m_Menu_Point;
    public struct MenuActions
    {
        private @PlayerControls m_Wrapper;
        public MenuActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MenuNavigation => m_Wrapper.m_Menu_MenuNavigation;
        public InputAction @Confirm => m_Wrapper.m_Menu_Confirm;
        public InputAction @UnPause => m_Wrapper.m_Menu_UnPause;
        public InputAction @MouseClick => m_Wrapper.m_Menu_MouseClick;
        public InputAction @Point => m_Wrapper.m_Menu_Point;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @MenuNavigation.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnMenuNavigation;
                @MenuNavigation.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnMenuNavigation;
                @MenuNavigation.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnMenuNavigation;
                @Confirm.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnConfirm;
                @Confirm.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnConfirm;
                @Confirm.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnConfirm;
                @UnPause.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnUnPause;
                @UnPause.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnUnPause;
                @UnPause.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnUnPause;
                @MouseClick.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnMouseClick;
                @MouseClick.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnMouseClick;
                @MouseClick.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnMouseClick;
                @Point.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnPoint;
                @Point.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnPoint;
                @Point.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnPoint;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MenuNavigation.started += instance.OnMenuNavigation;
                @MenuNavigation.performed += instance.OnMenuNavigation;
                @MenuNavigation.canceled += instance.OnMenuNavigation;
                @Confirm.started += instance.OnConfirm;
                @Confirm.performed += instance.OnConfirm;
                @Confirm.canceled += instance.OnConfirm;
                @UnPause.started += instance.OnUnPause;
                @UnPause.performed += instance.OnUnPause;
                @UnPause.canceled += instance.OnUnPause;
                @MouseClick.started += instance.OnMouseClick;
                @MouseClick.performed += instance.OnMouseClick;
                @MouseClick.canceled += instance.OnMouseClick;
                @Point.started += instance.OnPoint;
                @Point.performed += instance.OnPoint;
                @Point.canceled += instance.OnPoint;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);

    // InInteraction
    private readonly InputActionMap m_InInteraction;
    private IInInteractionActions m_InInteractionActionsCallbackInterface;
    private readonly InputAction m_InInteraction_ContinueInteract;
    public struct InInteractionActions
    {
        private @PlayerControls m_Wrapper;
        public InInteractionActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @ContinueInteract => m_Wrapper.m_InInteraction_ContinueInteract;
        public InputActionMap Get() { return m_Wrapper.m_InInteraction; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InInteractionActions set) { return set.Get(); }
        public void SetCallbacks(IInInteractionActions instance)
        {
            if (m_Wrapper.m_InInteractionActionsCallbackInterface != null)
            {
                @ContinueInteract.started -= m_Wrapper.m_InInteractionActionsCallbackInterface.OnContinueInteract;
                @ContinueInteract.performed -= m_Wrapper.m_InInteractionActionsCallbackInterface.OnContinueInteract;
                @ContinueInteract.canceled -= m_Wrapper.m_InInteractionActionsCallbackInterface.OnContinueInteract;
            }
            m_Wrapper.m_InInteractionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ContinueInteract.started += instance.OnContinueInteract;
                @ContinueInteract.performed += instance.OnContinueInteract;
                @ContinueInteract.canceled += instance.OnContinueInteract;
            }
        }
    }
    public InInteractionActions @InInteraction => new InInteractionActions(this);

    // Prompt
    private readonly InputActionMap m_Prompt;
    private IPromptActions m_PromptActionsCallbackInterface;
    private readonly InputAction m_Prompt_MovePrompt;
    private readonly InputAction m_Prompt_ConfirmPrompt;
    public struct PromptActions
    {
        private @PlayerControls m_Wrapper;
        public PromptActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MovePrompt => m_Wrapper.m_Prompt_MovePrompt;
        public InputAction @ConfirmPrompt => m_Wrapper.m_Prompt_ConfirmPrompt;
        public InputActionMap Get() { return m_Wrapper.m_Prompt; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PromptActions set) { return set.Get(); }
        public void SetCallbacks(IPromptActions instance)
        {
            if (m_Wrapper.m_PromptActionsCallbackInterface != null)
            {
                @MovePrompt.started -= m_Wrapper.m_PromptActionsCallbackInterface.OnMovePrompt;
                @MovePrompt.performed -= m_Wrapper.m_PromptActionsCallbackInterface.OnMovePrompt;
                @MovePrompt.canceled -= m_Wrapper.m_PromptActionsCallbackInterface.OnMovePrompt;
                @ConfirmPrompt.started -= m_Wrapper.m_PromptActionsCallbackInterface.OnConfirmPrompt;
                @ConfirmPrompt.performed -= m_Wrapper.m_PromptActionsCallbackInterface.OnConfirmPrompt;
                @ConfirmPrompt.canceled -= m_Wrapper.m_PromptActionsCallbackInterface.OnConfirmPrompt;
            }
            m_Wrapper.m_PromptActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MovePrompt.started += instance.OnMovePrompt;
                @MovePrompt.performed += instance.OnMovePrompt;
                @MovePrompt.canceled += instance.OnMovePrompt;
                @ConfirmPrompt.started += instance.OnConfirmPrompt;
                @ConfirmPrompt.performed += instance.OnConfirmPrompt;
                @ConfirmPrompt.canceled += instance.OnConfirmPrompt;
            }
        }
    }
    public PromptActions @Prompt => new PromptActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get
        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnDebugR1(InputAction.CallbackContext context);
        void OnDebugL1(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnDebug3(InputAction.CallbackContext context);
        void OnDebug4(InputAction.CallbackContext context);
        void OnDebug5(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnMenuNavigation(InputAction.CallbackContext context);
        void OnConfirm(InputAction.CallbackContext context);
        void OnUnPause(InputAction.CallbackContext context);
        void OnMouseClick(InputAction.CallbackContext context);
        void OnPoint(InputAction.CallbackContext context);
    }
    public interface IInInteractionActions
    {
        void OnContinueInteract(InputAction.CallbackContext context);
    }
    public interface IPromptActions
    {
        void OnMovePrompt(InputAction.CallbackContext context);
        void OnConfirmPrompt(InputAction.CallbackContext context);
    }
}

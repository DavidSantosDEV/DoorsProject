using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSwapper : MonoBehaviour //I DONT EVEN KNOW WHY THIS EXISTS
{
    [SerializeField]
    private Sprite[] avatars;
    [SerializeField]
    private InteractDialogue objectToSwap;

    public void AvatarSwap(int index)
    {
        if (avatars.Length > index)
        {
            objectToSwap?.SwapAvatar(avatars[index]);
        }
    }
}

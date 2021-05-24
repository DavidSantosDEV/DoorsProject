using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossZonesBehaviour : MonoBehaviour
{
    [SerializeField]
    BossBehaviour parent;
    [SerializeField]
    short number;

    BoxCollider2D myCol;

    private void Start()
    {
        myCol = GetComponent<BoxCollider2D>();
    }

    public void DoDamage(float calculated)
    {
        Vector2 pos = transform.position;
        
        //Collider2D hit = Physics2D.OverlapBox(pos + myCol.offset, myCol.size, 0, LayerMask.GetMask("Player"));
        if(Physics2D.OverlapBox(pos + myCol.offset, myCol.size, 0, LayerMask.GetMask("Player")))
        {
            GameManager.Instance.GetPlayer().PlayerHeartsComponent.TakeDamage(calculated);
            //PlayerController.Instance.playerHealthComponent.TakeDamage(calculated);
            //GamepadRumbler.Instance.RumbleLinear(3, 4, 6, 5, .2f);
            CameraShake.Instance.AddTrauma(.6f);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartAdd : MonoBehaviour
{
    [SerializeField]
    GameObject destroyMe;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance?.GetPlayer().PlayerHeartsComponent?.UpgradeHealth(1);
            MusicManager.Instance?.playBling();
            Destroy(gameObject);
            if (destroyMe)
            {
                Destroy(destroyMe);
            }
        }
    }
}

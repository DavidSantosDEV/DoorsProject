using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckPoint : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private string playerTag;

    public Vector2 GetSpawnPoint()
    {
        return spawnPoint.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            //Set currentSpawn Point

            GameManager.Instance?.SetCheckPoint(this);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    private CinemachineVirtualCamera cam;

    [SerializeField]
    private bool followPlayer=false;
    private void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
        if (followPlayer)
        {
            Transform target=null;
            if (GameManager.Instance)
            {
                target = GameManager.Instance.GetPlayer().transform;
            }
            else
            {
                target = FindObjectOfType<PlayerController>().transform;
            }
            cam.Follow = target;
        }
        else
        {
            Destroy(this);
        }
    }


}

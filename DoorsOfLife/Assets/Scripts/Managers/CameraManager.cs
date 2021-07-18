using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    private List<CinemachineVirtualCamera> camerasToClear;

    public static CameraManager Instance { get; private set; } = null;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private Transform player;

    private void Start()
    {
        player = GameManager.Instance!=null ? GameManager.Instance.GetPlayer().transform : FindObjectOfType<PlayerController>().transform;
    }


    private CinemachineVirtualCamera activeCamera;

    public void SwitchActiveCamera(CinemachineVirtualCamera newCamera, CinemachineBasicMultiChannelPerlin perlin)
    {
        if (newCamera)
        {
            if (activeCamera)
            {
                activeCamera.enabled = false;
            }
            newCamera.enabled = true;
            activeCamera = newCamera;
            CameraShake.Instance.SettupComponent(perlin);
        }  
    }
   
}

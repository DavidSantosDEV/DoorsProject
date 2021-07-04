using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
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

    private CinemachineVirtualCamera activeCamera;

    public void SwitchActiveCamera(CinemachineVirtualCamera newCamera)
    {
        if (newCamera)
        {
            if (activeCamera)
            {
                activeCamera.enabled = false;
            }
            newCamera.enabled = true;
            activeCamera = newCamera;
        }  
    }
}

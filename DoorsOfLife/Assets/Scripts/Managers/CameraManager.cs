using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private bool isFollowingTarget=false;

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

            if (isFollowingTarget)
            {
                activeCamera.Follow=currentTarget;
            }
            else
            {
                activeCamera.Follow = null;
            }
        }  
    }

    private Transform currentTarget=null;

    public void SetFollow(Transform target)
    {
        currentTarget = target;
        activeCamera.Follow = target;
        isFollowingTarget = target != null;
    }

    public void SetFollow(Transform target, float time)
    {
        currentTarget = target;
        activeCamera.Follow = target;
        isFollowingTarget = target != null;

        if (isFollowingTarget)
        {
            Invoke(nameof(ClearFollow), time);
        }
    }

    private void ClearFollow()
    {
        currentTarget = null;
        isFollowingTarget = false;
        activeCamera.Follow = null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target = null;
    
    [SerializeField]
    [Range(0.01f, 1f)]
    private float smoothTime = 0.125f;
    [SerializeField]
    private Vector3 offset = new Vector3(0, 0, -1.5f);

    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        if (!target)
        {
            target = PlayerController.Instance.transform;
        }

        //CameraShake.Instance.SettupComponent(transform);
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;


        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
    }
}

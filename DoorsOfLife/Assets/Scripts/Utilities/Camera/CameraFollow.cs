using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow Instance { get; private set; } = null;

    [SerializeField]
    private Transform target = null;
    
    [SerializeField]
    [Range(0.01f, 1f)]
    private float smoothTime = 0.125f;
    [SerializeField]
    private Vector3 offset = new Vector3(0, 0, -1.5f);

    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
           Destroy(gameObject);
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void Start()
    {
        if (!target)
        {
            target = GameManager.Instance.GetPlayer().transform;//PlayerController.Instance.transform;
        }

        //CameraShake.Instance.SettupComponent(transform);
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;


        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
    }
}

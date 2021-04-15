using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public bool camShakeActive = true;

    //private Transform cameraTransform=null;

    [SerializeField][Range(0,1)]
    private float trauma;

    [SerializeField][Range(0,1)]
    private float traumaFalloff = 0.2f;

    [SerializeField]
    private float traumaDecay = 1.3f;

    [SerializeField]
    private float traumaMultiplier=5;

    [SerializeField][Range(0,0.1f)]
    private float traumaMagnitude = 0.008f;


    public void AddTrauma(float value)
    {
        float newtrauma = trauma+value;
        trauma=Mathf.Clamp01(newtrauma);
    }


    private float timeCounter;

    public static CameraShake Instance { get; private set; } = null;

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
    /*public void SettupComponent(Transform camera)
    {
        cameraTransform = camera;
    }*/

    private float GetFloat(float seed)
    {
        return (Mathf.PerlinNoise(seed, timeCounter) - 0.5f) * 2;
    }

    private Vector3 GetVector3()
    {
        return new Vector3(
            GetFloat(1),
            GetFloat(10),
            0
            );
    }

    private void Update()
    {
        if (camShakeActive && trauma>0)
        {
            timeCounter += Time.deltaTime* Mathf.Pow(trauma,traumaFalloff/*0.2f*/)*traumaMultiplier;
            Vector3 newPos = GetVector3()*traumaMagnitude;
            transform.localPosition = transform.localPosition + newPos;
            trauma = Mathf.Clamp01(trauma- (Time.deltaTime * traumaDecay));
        }
    }
}

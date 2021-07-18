using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public bool camShakeActive = true;

    private float trauma = 0;

    [SerializeField]
    private float traumaMult=10;
    [SerializeField]
    private float traumaDecay=0.3f;
    //private Transform cameraTransform=null;

    /*[SerializeField][Range(0,1)]
    private float trauma;

    [SerializeField][Range(0,1)]
    private float traumaFalloff = 0.2f;

    [SerializeField]
    private float traumaDecay = 1.3f;

    [SerializeField]
    private float traumaMultiplier=5;

    [SerializeField][Range(0,0.1f)]
    private float traumaMagnitude = 0.008f;*/


    public void AddTrauma(float value)
    {
        float newtrauma = trauma+value;
        trauma=Mathf.Clamp01(newtrauma);
    }


    //private float timeCounter;

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

    //private CinemachineVirtualCamera cam;
    private CinemachineBasicMultiChannelPerlin perlinChanel;
    public void SettupComponent(CinemachineBasicMultiChannelPerlin newCam)
    {
        perlinChanel = newCam;
    }

    private void Update()
    {
        if (camShakeActive && trauma>0)
        {
            //timeCounter += Time.deltaTime* Mathf.Pow(trauma,traumaFalloff/*0.2f*/)*traumaMultiplier;
            //Vector3 newPos = GetVector3()*traumaMagnitude;
            if (perlinChanel)
            {
                perlinChanel.m_AmplitudeGain = trauma*traumaMult;
                //transform.localPosition = transform.localPosition + newPos;
            }
            trauma = Mathf.Clamp01(trauma- (Time.deltaTime * traumaDecay));
        }
    }
}

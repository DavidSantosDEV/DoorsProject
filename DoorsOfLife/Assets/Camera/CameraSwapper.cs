using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;
using Cinemachine;
public class CameraSwapper : MonoBehaviour
{
    [SerializeField]
    private Light2D[] lights;

    [SerializeField]
    private bool followPlayer=false;

    private CinemachineVirtualCamera myCamera;

    [SerializeField]
    private float waitLightsOFF=1;

    bool shutlights = false;

    Collider2D col;

    private CinemachineBasicMultiChannelPerlin perlin;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
        myCamera = GetComponentInChildren<CinemachineVirtualCamera>();
        perlin = myCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        if (perlin)
        {
            perlin.m_AmplitudeGain = 0;
        }
    }

    private void Start()
    {

        lights = lights.Where(val => val != null).ToArray();
        if (followPlayer)
        {
            myCamera.GetCinemachineComponent<CinemachineTransposer>().m_BindingMode = CinemachineTransposer.BindingMode.LockToTargetWithWorldUp;
            if (GameManager.Instance)
            {
                myCamera.Follow = GameManager.Instance.GetPlayer().transform;
            }
            else
            {
                myCamera.Follow = FindObjectOfType<PlayerController>().transform;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerFeet"))
        {
            CameraManager.Instance?.SwitchActiveCamera(myCamera,perlin);
            //myCamera.enabled = true;
            shutlights = false;
            CancelInvoke(nameof(waitLightsOFF));
            foreach (Light2D light in lights)
            {
                if(light)
                light.enabled = true;
            }
        }
    }

    private void LightsOFF()
    {
        col.isTrigger = true;
        if (shutlights) //cancel invoke doesnt work??
        {
            foreach (Light2D light in lights)
            {
                if(light)
                light.enabled = false;
            }
        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //myCamera.enabled = false;
            col.isTrigger = false;
            shutlights = true;
            Invoke(nameof(LightsOFF), waitLightsOFF);
        }
    }

    
}

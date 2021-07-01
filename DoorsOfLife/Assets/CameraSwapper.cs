using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;
using Cinemachine;
public class CameraSwapper : MonoBehaviour
{
    [SerializeField]
    private Light2D[] lights;

    private CinemachineVirtualCamera myCamera;

    [SerializeField]
    private float waitLightsOFF=1;

    bool shutlights = false;

    private void Awake()
    {
        myCamera = GetComponentInChildren<CinemachineVirtualCamera>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CameraManager.Instance?.SwitchActiveCamera(myCamera);
            //myCamera.enabled = true;
            shutlights = false;
            CancelInvoke(nameof(waitLightsOFF));
            foreach (Light2D light in lights)
            {
                light.enabled = true;
            }
        }
    }

    private void LightsOFF()
    {
        if (shutlights) //cancel invoke doesnt work??
        {
            foreach (Light2D light in lights)
            {
                light.enabled = false;
            }
        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //myCamera.enabled = false;
            shutlights = true;
            Invoke(nameof(LightsOFF), waitLightsOFF);
        }
    }
}

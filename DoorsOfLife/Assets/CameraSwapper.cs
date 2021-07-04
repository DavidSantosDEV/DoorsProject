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

    Collider2D col;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
        myCamera = GetComponentInChildren<CinemachineVirtualCamera>();
        //Rigidbody2D bd = gameObject.AddComponent<Rigidbody2D>();
        //bd.gravityScale = 0;
        //bd.sleepMode = RigidbodySleepMode2D.NeverSleep;
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
        col.isTrigger = true;
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
            col.isTrigger = false;
            shutlights = true;
            Invoke(nameof(LightsOFF), waitLightsOFF);
        }
    }

    
}

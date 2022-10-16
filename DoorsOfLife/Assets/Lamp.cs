using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Lamp : MonoBehaviour
{
    [SerializeField]
    private LightColorChanger master;

    [SerializeField]
    private UnityEngine.Rendering.Universal.Light2D myLight;

    private float time = 1;

    private float intensity=0;

    private void Awake()
    {
        time = master.SpeedTime;
        myLight.intensity = 0;
    }

    private void Start()
    {
        master.AddReference(this);
    }

    public void IncrementLight(float val)
    {
        StartCoroutine(StartAdd(val));
    }

    private IEnumerator StartAdd(float val)
    {
        float temp = Mathf.Abs( Mathf.Clamp01(intensity + val));
        float delta=0;
        while (intensity<temp)
        {
            delta += Time.deltaTime * (1/time);
            intensity = delta;

            myLight.intensity = intensity;
            yield return null;
        }
        intensity = temp;
        myLight.intensity = intensity;
    }
}

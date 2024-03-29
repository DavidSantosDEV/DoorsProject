using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    [SerializeField]
    private float ScaleOfX=1;
    [SerializeField]
    private float Minspeed=1,MaxSpeed=40;
    UnityEngine.Rendering.Universal.Light2D myLight;

    // Start is called before the first frame update
    void Awake()
    {
        myLight = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enabled)
        {
            myLight.intensity= Random.Range( Mathf.PerlinNoise(Time.deltaTime * ScaleOfX, 0), 1);
        }
    }

    private IEnumerator Flicker()
    {
        while (enabled)
        {
            myLight.enabled = true;
            yield return new WaitForSeconds(1 / Random.Range(Minspeed, MaxSpeed));
            myLight.enabled = false;
            yield return new WaitForSeconds(1/Random.Range(Minspeed, MaxSpeed));
        }
        
    }

    private void OnBecameInvisible()
    {
        enabled = false;
    }

    private void OnBecameVisible()
    {
        enabled = true;
        StartCoroutine(Flicker());
    }
}

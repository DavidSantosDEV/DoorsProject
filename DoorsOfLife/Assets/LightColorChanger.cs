using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;

public class LightColorChanger : MonoBehaviour
{
    [SerializeField]
    private Light2D myLight;

    [SerializeField]
    private Color[] colors;

    [SerializeField][Range(0.01f,100)]
    private float time=1;

    private bool isLerping = false;

    private List<int> nextInLine = new List<int>();

    public void ChangeColor(int index)
    {
        if(colors.Length > index)
        {
            if (colors[index] == myLight.color)
            {
                return;
            }
            if (isLerping==false)
            {
                StartCoroutine(ColorChanging(index));
            }
            else
            {
                nextInLine.Add(index);
            }
        }
    }

    private IEnumerator ColorChanging(int index)
    {
        isLerping = true;
        Color ogColor = myLight.color;
        float delta=0;
        while (myLight.color != colors[index])
        {
            delta += Time.deltaTime * ( 1/ time);
            myLight.color = Color.Lerp(ogColor, colors[index], delta);
            Debug.Log("Activating");
            yield return null;
        }
        isLerping = false;
        if (nextInLine.Count > 0)
        {
            StartCoroutine(ColorChanging(nextInLine[0]));
            nextInLine.RemoveAt(0);
        }
    }
}

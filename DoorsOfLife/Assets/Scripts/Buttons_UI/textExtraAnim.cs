using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textExtraAnim : MonoBehaviour
{
    private TextMeshProUGUI text;

    [SerializeField]
    private float speed=1;
    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    private IEnumerator AnimateText()
    {
        while (enabled)
        {
            text.text = "Loading";
            yield return new WaitForSeconds(1 / speed);
            text.text = "Loading.";
            yield return new WaitForSeconds(1 / speed);
            text.text = "Loading..";
            yield return new WaitForSeconds(1 / speed);
            text.text = "Loading...";
            yield return new WaitForSeconds(1 / speed);
        }
    }
}

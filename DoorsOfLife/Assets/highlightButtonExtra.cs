using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine;

public class highlightButtonExtra : MonoBehaviour,ISelectHandler,IDeselectHandler,IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private Color highlightColor;

    private Color originalColor;

    public void OnSelect(BaseEventData eventData)
    {
        ChangeColor();
    }

    public void OnDeselect(BaseEventData eventData)
    {
        ReturnColor();
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        ChangeColor();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ReturnColor();
    }

    private void ChangeColor()
    {
        text.color = new Color(highlightColor.r,highlightColor.g,highlightColor.b,highlightColor.a);
    }

    private void ReturnColor()
    {
        text.color = originalColor;
    }

    void Start()
    {
        if (!text)
        {
            text = GetComponentInChildren<TextMeshProUGUI>();
        }
        originalColor = text.color;

    }

}

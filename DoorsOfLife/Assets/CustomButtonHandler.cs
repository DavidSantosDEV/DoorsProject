using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class CustomButtonHandler : MonoBehaviour, ISelectHandler, IPointerEnterHandler, IPointerExitHandler, IDeselectHandler
{
    [SerializeField]
    private GameObject objectToShow;


    void Awake()
    {
        objectToShow.SetActive(false);
    }

    public void OnSelect(BaseEventData data)
    {
        objectToShow.SetActive(true);
    }
    public void OnDeselect(BaseEventData eventData)
    {
        objectToShow.SetActive(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }
}

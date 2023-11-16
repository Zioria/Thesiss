using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CheckZoom : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isZoom;

    private void Awake()
    {
        isZoom = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isZoom = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isZoom = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField, TextArea] private string message;

    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipManager.ShowToolTip_Static(message);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipManager.HideToolTip_Static();
    }
}

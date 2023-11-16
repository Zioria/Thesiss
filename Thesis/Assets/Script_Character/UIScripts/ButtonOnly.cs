using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ButtonOnly : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private PlayerInput playerInput;

    public void OnPointerEnter(PointerEventData eventData)
    {
        playerInput.enabled = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        playerInput.enabled = true;
    }
}

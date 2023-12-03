using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MapHolderUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private CursorControl uiCursorControl;
    public bool IsOpen;
    
    
    public void OnMap(InputValue value)
    {
        if (IsOpen)
        {
            IsOpen = false;
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
            uiCursorControl.CloseMenu();
            return;
            
        }
        
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        uiCursorControl.OpenMenu();

        IsOpen = true;
    }

    public void CheckOpen()
    {
        IsOpen = false;
    }
    
}

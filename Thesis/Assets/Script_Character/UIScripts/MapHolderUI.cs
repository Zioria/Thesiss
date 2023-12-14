using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MapHolderUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup mapHolderCanvasGroup;
    [SerializeField] private CanvasGroup largeMapHolderCanvasGroup;
    [SerializeField] private CanvasGroup miniMapHolderCanvasGroup;
    [SerializeField] private CursorControl uiCursorControl;
    public bool IsOpen;
    
    
    public void OnMap(InputValue value)
    {
        if (IsOpen)
        {
            IsOpen = false;
            mapHolderCanvasGroup.alpha = 0;
            mapHolderCanvasGroup.blocksRaycasts = false;
            largeMapHolderCanvasGroup.blocksRaycasts = false;
            miniMapHolderCanvasGroup.alpha = 1;
            uiCursorControl.CloseMenu();
            return;
            
        }
        
        mapHolderCanvasGroup.alpha = 1;
        mapHolderCanvasGroup.blocksRaycasts = true;
        largeMapHolderCanvasGroup.blocksRaycasts = true;
        miniMapHolderCanvasGroup.alpha = 0;
        uiCursorControl.OpenMenu();

        IsOpen = true;
    }

    public void OpenMap()
    {
        IsOpen = true;
    }

    public void CloseMap()
    {
        IsOpen = false;
    }
    
}

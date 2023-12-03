using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapHolderUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private CursorControl uiCursorControl;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;
            uiCursorControl.OpenMenu();
        }
    }

}

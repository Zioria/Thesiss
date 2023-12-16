using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MapHolderUI : MonoBehaviour
{
    [SerializeField] private GameObject mapHolder;
    [SerializeField] private GameObject largeMapHolder;
    [SerializeField] private GameObject miniMapHolder;
    [SerializeField] private CursorControl uiCursorControl;
    [SerializeField] private CheckCharacterActive checkCharActive;
    [SerializeField] private CloseUIQuest closeUIQuest;
    public bool IsOpen;

    private void OnEnable()
    {
        Shortcutscript.OnMinimapClick += ToggleMap;
    }

    private void OnDisable()
    {
        Shortcutscript.OnMinimapClick -= ToggleMap;
    }

    private void Start()
    {
        IsOpen = false;
        mapHolder.SetActive(IsOpen);
        largeMapHolder.SetActive(IsOpen);
        miniMapHolder.SetActive(!IsOpen);
    }

    public void ToggleMap()
    {
        if (checkCharActive.IsOpen || closeUIQuest.IsOpen)
        {
            return;
        }

        IsOpen = !IsOpen;
        if (IsOpen)
        {
            mapHolder.SetActive(IsOpen);
            largeMapHolder.SetActive(IsOpen);
            miniMapHolder.SetActive(!IsOpen);
            uiCursorControl.OpenMenu();
            return;

        }

        mapHolder.SetActive(IsOpen);
        largeMapHolder.SetActive(IsOpen);
        miniMapHolder.SetActive(!IsOpen);
        uiCursorControl.CloseMenu();
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

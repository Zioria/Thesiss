using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUIQuest : MonoBehaviour
{
    [SerializeField] private GameObject closeUIQuest;
    [SerializeField] private CursorControl uiCursorControl;

    [SerializeField] private MapHolderUI mapHolderUI;
    [SerializeField] private CheckCharacterActive checkCharActive;

    public bool IsOpen;

    private void OnEnable()
    {
        Shortcutscript.OnQuestClick += ToggleQuest;
    }

    private void OnDisable()
    {
        Shortcutscript.OnQuestClick -= ToggleQuest;
    }

    private void Start()
    {
        IsOpen = false;
        closeUIQuest.SetActive(IsOpen);
        
    }

    public void ToggleQuest()
    {
        if (mapHolderUI.IsOpen || checkCharActive.IsOpen)
        {
            return;
        }

        IsOpen = !IsOpen;
        if (IsOpen)
        {
            closeUIQuest.SetActive(IsOpen);
            uiCursorControl.OpenMenu();
            return;
        }
        closeUIQuest.SetActive(IsOpen);
        uiCursorControl.CloseMenu();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCharacterActive : MonoBehaviour
{
    [SerializeField] private GameObject girlCanvas;
    [SerializeField] private GameObject boyCanvas;
    [SerializeField] private GameObject BG;
    [SerializeField] private CursorControl uiCursorControl;
    [SerializeField] private AttributeManagerBoy AMBoy;
    [SerializeField] private AttributeManagerGirl AMGirl;
    [SerializeField] private GameObject statusButton;
    [SerializeField] private CharacterStatUI girlStatUI;
    [SerializeField] private CharacterStatUI boyStatUI;

    [SerializeField] private MapHolderUI mapHolderUI;
    [SerializeField] private CloseUIQuest closeUIQuest;
    private CharacterStats[] stats => CharacterStatusUI.Instance.Stats;
    private CharacterStats stat;

    public bool IsOpen;

    private void OnEnable()
    {
        Shortcutscript.OnStatusClick += ToggleStatus;
    }

    private void OnDisable()
    {
        Shortcutscript.OnStatusClick -= ToggleStatus;
    }


    private void Start()
    {
        IsOpen = false;
        girlCanvas.SetActive(false);
        boyCanvas.SetActive(false);
        BG.SetActive(false);
    }

    public void ToggleStatus()
    {
        if (mapHolderUI.IsOpen || closeUIQuest.IsOpen)
        {
            return;
        }

        IsOpen = !IsOpen;
        BG.SetActive(IsOpen);
        statusButton.SetActive(!IsOpen);
        if (IsOpen)
        {
            uiCursorControl.OpenMenu();
        }
        else
        {
            uiCursorControl.CloseMenu();
        }

        AMBoy.UpdateAttributeUI();
        AMGirl.UpdateAttributeUI();
        girlStatUI.ConfirmPressed_Static();
        boyStatUI.ConfirmPressed_Static();

        stat = CharacterStatusUI.Instance.CurrentActive(stats);
        if (stat.name == "Mc_G")
        {
            girlCanvas.SetActive(true);
            boyCanvas.SetActive(false);
            return;
        }

        girlCanvas.SetActive(false);
        boyCanvas.SetActive(true);
    }
}

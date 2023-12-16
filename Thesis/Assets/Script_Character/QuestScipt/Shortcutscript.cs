using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shortcutscript : MonoBehaviour
{
    public static event Action OnStatusClick;
    public static event Action OnMinimapClick;
    public static event Action OnQuestClick;


    public void OnQuest(InputValue value)
    {
        OnQuestClick?.Invoke();
    }

    public void OnStatus(InputValue value)
    {
        OnStatusClick?.Invoke();
    }

    public void OnMap(InputValue value)
    {
        OnMinimapClick?.Invoke();
    }
}

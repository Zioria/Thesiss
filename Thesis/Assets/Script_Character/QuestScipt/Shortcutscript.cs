using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shortcutscript : MonoBehaviour
{
    [SerializeField] private GameObject QuestUI;
    

    private void Awake()
    {
        QuestUI.SetActive(false);
       
    }

    public void OnQuest(InputValue value)
    {
       QuestUI.SetActive(!QuestUI.activeSelf);

       
    }

    public void OnStatus(InputValue value)
    {
        Debug.Log("Status");
    }

    
}

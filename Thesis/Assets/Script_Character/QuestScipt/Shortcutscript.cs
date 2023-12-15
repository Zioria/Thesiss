using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shortcutscript : MonoBehaviour
{
    [SerializeField] private GameObject QuestUI;
   // [SerializeField] private GameObject StatusUI;
    
    //public static Shortcutscript Instance;

    private void Awake()
    {
        QuestUI.SetActive(false);
       // StatusUIUI.SetActive(false);
       
    }

    public void OnQuest(InputValue value)
    {
       QuestUI.SetActive(!QuestUI.activeSelf);
       
       //if()
      // {

       //}
       
    }

    public void OnStatus(InputValue value)
    {
       //StatusUI.SetActive(!StatusUI.activeSelf);
    }

    
}

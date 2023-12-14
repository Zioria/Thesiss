using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shortcutscript : MonoBehaviour
{
    public PlayerInput _input;


    private void Awake()
    {
        _input.GetComponent<PlayerInput>();
    }

    public void OnQuest(InputValue value)
    {
        Debug.Log("Quest");
    }

    public void OnStatus(InputValue value)
    {
        Debug.Log("Status");
    }
}

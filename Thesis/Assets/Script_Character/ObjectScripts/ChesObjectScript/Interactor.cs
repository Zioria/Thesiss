using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    public static Interactor Instance;

    [SerializeField] private GameObject interactUI;

    public bool IsInteracting;

    private void Awake()
    {
        if (Instance == null && Instance != this)
        {
            Instance = this;
        }

        interactUI.SetActive(IsInteracting);
    }

    private void Update()
    {
        interactUI.SetActive(IsInteracting);
    }
}

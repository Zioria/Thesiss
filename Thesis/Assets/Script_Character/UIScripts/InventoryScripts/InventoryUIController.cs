using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryUIController : MonoBehaviour
{
    [SerializeField] private int backpackSlot;
    [SerializeField] private DynamicInventoryDisplay chestPanel;
    [SerializeField] private DynamicInventoryDisplay playerBackpackPanel;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField, Tooltip("Find in UI gameobject")] private CursorControl cursorControl;
    [SerializeField, Tooltip("Find in Player gameobject")] private PlayerInventoryHolder playerInvHolder;
    

    private void Awake()
    {
        chestPanel.gameObject.SetActive(false);
        playerBackpackPanel.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        InventoryHolder.OnDynamicInventoryDisplayRequested += DisplayInventory;
        PlayerInventoryHolder.OnPlayerBackpackDisplayRequested += DisplayPlayerBackpack;
    }

    private void OnDisable()
    {
        InventoryHolder.OnDynamicInventoryDisplayRequested -= DisplayInventory;
        PlayerInventoryHolder.OnPlayerBackpackDisplayRequested -= DisplayPlayerBackpack;
    }

    private void DisplayInventory(InventorySystem invToDisplay)
    {
        chestPanel.gameObject.SetActive(true);
        chestPanel.RefreshDynamicInventory(invToDisplay);
    }

    private void DisplayPlayerBackpack(InventorySystem invToDisplay)
    {
        playerBackpackPanel.gameObject.SetActive(true);
        playerBackpackPanel.RefreshDynamicInventory(invToDisplay);
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape))
        {
            return;
        }
        if (chestPanel.gameObject.activeInHierarchy)
        {
            chestPanel.gameObject.SetActive(false);
            playerInput.enabled = true;
        }
        if (playerBackpackPanel.gameObject.activeInHierarchy)
        {
            playerBackpackPanel.gameObject.SetActive(false);
            playerInput.enabled = true;
        }
        cursorControl.CloseMenu();
        playerInvHolder.IsOpening = false;
    }
}

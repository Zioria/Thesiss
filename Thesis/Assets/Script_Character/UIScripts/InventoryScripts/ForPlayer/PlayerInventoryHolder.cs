using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInventoryHolder : InventoryHolder
{
    [SerializeField] protected int secondaryInventorySize;
    [SerializeField] protected InventorySystem secondaryInventorySystem;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private CursorControl cursorControl;

    public InventorySystem SecondaryInventorySystem => secondaryInventorySystem;

    public static UnityAction<InventorySystem> OnPlayerBackpackDisplayRequested;

    public bool IsOpening;

    protected override void Awake()
    {
        base.Awake();

        secondaryInventorySystem = new InventorySystem(secondaryInventorySize);
    }

    private void Update()
    {
        //if (IsOpening)
        //{
        //    return;
        //}

        //if (!Input.GetKeyDown(KeyCode.B))
        //{
        //    return;
        //}
        //OnPlayerBackpackDisplayRequested?.Invoke(secondaryInventorySystem);
        //playerInput.enabled = false;
        //cursorControl.OpenMenu();
        //IsOpening = true;
    }

    public bool AddToInventory(ItemScriptable data, int amount)
    {
        if (primaryInventorySystem.AddToInventory(data, amount) || 
            secondaryInventorySystem.AddToInventory(data, amount))
        {
            return true;
        }

        return false;
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

public class StaticInventoryDisplay : InventoryDisplay
{
    [SerializeField] private InventoryHolder invHolder;
    [SerializeField] protected HotBar_UI[] slots;

    protected override void Start()
    {
        base.Start();

        if (invHolder == null)
        {
            Debug.LogWarning("No Inventory assigned to " + gameObject);
            return;
        }
        inventorySystem = invHolder.PrimaryInventorySystem;
        inventorySystem.OnInventorySlotChanged += UpdateSlot;

        AssignSlot(inventorySystem);
    }

    public override void AssignSlot(InventorySystem invToDisplay)
    {
        slotDictionary = new Dictionary<HotBar_UI, InventorySlot>();

        for (int i = 0; i < inventorySystem.InventorySize; i++)
        {
            // Add item to Dictionary
            slotDictionary.Add(slots[i], inventorySystem.InventorySlots[i]);
            slots[i].Init_Static(inventorySystem.InventorySlots[i]);
        }
    }
}

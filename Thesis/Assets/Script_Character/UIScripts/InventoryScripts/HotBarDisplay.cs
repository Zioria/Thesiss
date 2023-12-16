using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotBarDisplay : StaticInventoryDisplay
{

    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Z))
        {
            UseItem(0);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            UseItem(1);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            UseItem(2);
        }
        
    }

    private void UseItem(int index)
    {
        if (slots[index].InventorySlot.ItemData == null)
        {
            Debug.LogWarning("Did not assign inventory");
            return;
        }
        slots[index].InventorySlot.ItemData.UseItem();
        if (slots[index].InventorySlot.StackSize <= 1)
        {
            slots[index].ClearSlot();
            return;
        }
        slots[index].InventorySlot.AddToStack(-1);
        slots[index].UpdateUISlot();
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public abstract class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private MouseItemData mouseInventoryItem;
    protected InventorySystem inventorySystem;
    protected Dictionary<HotBar_UI, InventorySlot> slotDictionary;

    public InventorySystem InventorySystem => inventorySystem;
    public Dictionary<HotBar_UI, InventorySlot> SlotDictionary => slotDictionary;

    public abstract void AssignSlot(InventorySystem invToDisplay);

    protected virtual void Start() { }

    protected virtual void UpdateSlot(InventorySlot updatedSlot)
    {
        foreach (var slot in SlotDictionary)
        {
            if (slot.Value == updatedSlot) // Slot value - the "under the hood" inventory slot
            {
                slot.Key.UpdateUISlot_Static(updatedSlot); // Slot key - the UI representation of key
            }
        }
    }

    public void SlotClicked(HotBar_UI clickedSlot)
    {
        // Slot has item , mouse not has item
        if (clickedSlot.InventorySlot.ItemData != null && mouseInventoryItem.InventorySlot.ItemData == null)
        {
            if (Input.GetKey(KeyCode.LeftControl) && clickedSlot.InventorySlot.SplitStack(out InventorySlot halfStackSlot))
            {
                mouseInventoryItem.UpdateMouseSlot(halfStackSlot);
                clickedSlot.UpdateUISlot();
                return;
            }

            mouseInventoryItem.UpdateMouseSlot(clickedSlot.InventorySlot);
            clickedSlot.ClearSlot();
            return;
        }

        // Slot not hat item , mouse has item
        if (clickedSlot.InventorySlot.ItemData == null && mouseInventoryItem.InventorySlot.ItemData != null)
        {
            clickedSlot.InventorySlot.AssignItem(mouseInventoryItem.InventorySlot);
            clickedSlot.UpdateUISlot();

            mouseInventoryItem.ClearSlot_Static();
            return;
        }

        // Slot has item , mouse has item
            //Item not same
        if (clickedSlot.InventorySlot.ItemData != mouseInventoryItem.InventorySlot.ItemData)
        {
            SwapSlots(clickedSlot);
            return;
        }

        //Item same
            //Has room left
        if (clickedSlot.InventorySlot.RoomLeftInStack(mouseInventoryItem.InventorySlot.StackSize))
        {
            clickedSlot.InventorySlot.AssignItem(mouseInventoryItem.InventorySlot);
            clickedSlot.UpdateUISlot();

            mouseInventoryItem.ClearSlot_Static();
            return;
        }
            //Not has room left out how much left
        if (clickedSlot.InventorySlot.RoomLeftInStack(mouseInventoryItem.InventorySlot.StackSize, out int leftInStack))
        {
            return;
        }
        if (leftInStack < 1) // Stack is full , swap item
        {
            SwapSlots(clickedSlot);
            return;
        }
        // Stack not full , take amount then add
        int remainingOnmouse = mouseInventoryItem.InventorySlot.StackSize - leftInStack;
        clickedSlot.InventorySlot.AddToStack(leftInStack);
        clickedSlot.UpdateUISlot();

        var newItem = new InventorySlot(mouseInventoryItem.InventorySlot.ItemData, remainingOnmouse);
        mouseInventoryItem.ClearSlot_Static();
        mouseInventoryItem.UpdateMouseSlot(newItem);
    }

    private void SwapSlots(HotBar_UI clickedSlot)
    {
        var clonedSlot = new InventorySlot(mouseInventoryItem.InventorySlot.ItemData, mouseInventoryItem.InventorySlot.StackSize);

        mouseInventoryItem.ClearSlot_Static();

        mouseInventoryItem.UpdateMouseSlot(clickedSlot.InventorySlot);

        clickedSlot.ClearSlot();

        clickedSlot.InventorySlot.AssignItem(clonedSlot);
        clickedSlot.UpdateUISlot();
    }
}

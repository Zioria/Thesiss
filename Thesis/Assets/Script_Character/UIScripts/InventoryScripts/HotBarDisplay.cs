using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotBarDisplay : StaticInventoryDisplay
{
    private int _maxIndexSize = 1;
    private int _currentIndex = 0;

    protected override void Start()
    {
        base.Start();

        _currentIndex = 0;
        _maxIndexSize = slots.Length - 1;

        slots[_currentIndex].ToggleHighlight();
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {
            ChangeIndex(1);
        }

        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {
            ChangeIndex(-1);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            UseItem();
        }
    }

    private void UseItem()
    {
        if (slots[_currentIndex].InventorySlot.ItemData == null)
        {
            Debug.LogWarning("Did not assign inventory");
            return;
        }
        slots[_currentIndex].InventorySlot.ItemData.UseItem();
        if (slots[_currentIndex].InventorySlot.StackSize <= 1)
        {
            slots[_currentIndex].ClearSlot();
            return;
        }
        slots[_currentIndex].InventorySlot.AddToStack(-1);
        slots[_currentIndex].UpdateUISlot();
    }

    private void ChangeIndex(int direction)
    {
        slots[_currentIndex].ToggleHighlight();

        _currentIndex += direction;

        if (_currentIndex > _maxIndexSize)
        {
            _currentIndex = 0;
        }
        if (_currentIndex < 0)
        {
            _currentIndex = _maxIndexSize;
        }
        slots[_currentIndex].ToggleHighlight();
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class MouseItemData : MonoBehaviour
{
    [SerializeField] private Image itemSprite;
    [SerializeField] private TextMeshProUGUI itemCount;
    [SerializeField] private float dropOffset;

    public InventorySlot InventorySlot;
    private Transform _playerTransform;

    private void Awake()
    {
        itemSprite.color = Color.clear;
        itemSprite.preserveAspect = true;
        itemCount.text = "";

        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (_playerTransform == null)
        {
            Debug.LogError("Not assign Player Tag");
        }
    }

    public void UpdateMouseSlot(InventorySlot invSlot)
    {
        InventorySlot.AssignItem(invSlot);
        UpdateMouseSlot();
    }

    public void UpdateMouseSlot()
    {
        itemSprite.sprite = InventorySlot.ItemData.IconItem;
        itemCount.text = InventorySlot.StackSize.ToString();
        itemSprite.color = Color.white;
    }

    private void Update()
    {
        if (InventorySlot.ItemData == null)
        {
            return;
        }
        transform.position = Input.mousePosition;

        if (!Input.GetMouseButtonDown(0) || IsPointerOverObject())
        {
            return;
        }
        if (InventorySlot.ItemData.ItemPrefab != null)
        {
            Instantiate(InventorySlot.ItemData.ItemPrefab, _playerTransform.position + _playerTransform.forward * dropOffset, Quaternion.identity);
        }

        if (InventorySlot.StackSize <= 1)
        {
            ClearSlot();
            return;
        }
        InventorySlot.AddToStack(-1);
        UpdateMouseSlot();
    }

    private void ClearSlot()
    {
        InventorySlot.ClearSlot();
        itemSprite.color = Color.clear;
        itemSprite.sprite = null;
        itemCount.text = "";
    }

    public void ClearSlot_Static()
    {
        ClearSlot();
    }

    public static bool IsPointerOverObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}

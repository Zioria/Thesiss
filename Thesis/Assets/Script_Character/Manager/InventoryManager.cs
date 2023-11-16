using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<ItemScriptable> _items = new List<ItemScriptable>();
    private InventoryItemController[] _inventoryItem;

    [SerializeField] private Transform contentTranform;
    [SerializeField] private GameObject inventoryItem;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(ItemScriptable item)
    {
        _items.Add(item);
    }

    public void Remove(ItemScriptable item)
    {
        _items.Remove(item);
    }

    public void ListItem()
    {
        CleanInventory();

        foreach (var item in _items)
        {
            GameObject obj = Instantiate(inventoryItem, contentTranform);
            var itemName = obj.transform.Find("NameText").GetComponent<Text>();
            var itemIcon = obj.transform.Find("Icon").GetComponent<Image>();
            var removeBtn = obj.transform.Find("RemoveBtn").GetComponent<Button>();

            itemName.text = item.ItemName;
            itemIcon.sprite = item.IconImage;
        }

        SetInventoryItem();
    }

    private void SetInventoryItem()
    {
        _inventoryItem = contentTranform.GetComponentsInChildren<InventoryItemController>();

        //Set Item in Inventory match with list
        for (int i = 0; i < _items.Count; i++)
        {
            _inventoryItem[i].AddItem(_items[i]);
        }
    }
    public void CleanInventory()
    {
        //Prevent Item Duplicate
        foreach (Transform item in contentTranform)
        {
            Destroy(item.gameObject);
        }
    }
}

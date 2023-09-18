using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    private List<ItemScriptable> _items = new List<ItemScriptable>();
    private InventoryItemController[] _inventoryItem;

    [SerializeField] private Transform contentTranform;
    [SerializeField] private GameObject inventoryItem;
    [SerializeField] private Toggle toggleRemove;

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
        //Prevent Item Duplicate
        foreach (Transform item in contentTranform)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in _items)
        {
            GameObject obj = Instantiate(inventoryItem, contentTranform);
            var itemName = obj.transform.Find("NameText").GetComponent<Text>();
            var itemIcon = obj.transform.Find("Icon").GetComponent<Image>();
            var removeBtn = obj.transform.Find("RemoveBtn").GetComponent<Button>();

            itemName.text = item.ItemName;
            itemIcon.sprite = item.IconImage;
            if (toggleRemove.isOn)
            {
                removeBtn.gameObject.SetActive(true);
            }
        }

        SetInventoryItem();
    }

    public void EnableItemRemove()
    {
        if (!toggleRemove.isOn)
        {
            foreach (Transform item in contentTranform)
            {
                item.Find("RemoveBtn").gameObject.SetActive(false);
            }
            return;
        }
        foreach (Transform item in contentTranform)
        {
            item.Find("RemoveBtn").gameObject.SetActive(true);
        }
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
}

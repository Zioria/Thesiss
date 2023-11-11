using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    private ItemScriptable _item;
    private CharacterStats[] _stats;
    private CharacterStats _stat;

    [SerializeField] private Button removeBtn;

    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(_item);
        Destroy(gameObject);
    }

    public void AddItem(ItemScriptable newItem)
    {
        _item = newItem;
    }

    public void UseItem()
    {
        _stats = CharacterStatusUI.Instance.Stats;
        _stat = CharacterStatusUI.Instance.CurrentActive(_stats);

        Debug.Log(_stat);
        Debug.Log(_item.Value);
        _stat.HealDamage(_item.Value);

        RemoveItem();
    }
}

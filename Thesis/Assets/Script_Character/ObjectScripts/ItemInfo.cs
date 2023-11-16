using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject _potionInfoTab;

    private void Awake()
    {
        _potionInfoTab = GameObject.Find("/UI/Inventory/InventoryMenu/InventoryLayout/InfoTab/PotionInfo");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _potionInfoTab.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _potionInfoTab.SetActive(false);
    }
}

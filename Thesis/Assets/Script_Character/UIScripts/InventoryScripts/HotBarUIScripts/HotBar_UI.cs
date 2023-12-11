using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class HotBar_UI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image itemSprite;
    [SerializeField] private TextMeshProUGUI itemCount;
    [SerializeField] private InventorySlot inventorySlot;
    [SerializeField] private GameObject slotHighlight;

    private Button _btn;

    public InventorySlot InventorySlot => inventorySlot;
    public InventoryDisplay InvDisplay { get; private set; }


    private void Awake()
    {
        ClearSlot();

        itemSprite.preserveAspect = true;
        _btn = GetComponent<Button>();
        _btn?.onClick.AddListener(OnUISlotClick);

        InvDisplay = transform.parent.GetComponent<InventoryDisplay>();
    }

    private void Init(InventorySlot slot)
    {
        inventorySlot = slot;
        UpdateUISlot(slot);
    }

    public void Init_Static(InventorySlot slot)
    {
        Init(slot);
    }

    private void UpdateUISlot(InventorySlot slot)
    {
        if (slot.ItemData == null)
        {
            ClearSlot();
            return;
        }

        itemSprite.sprite = slot.ItemData.IconItem;
        itemSprite.color = Color.white;
        if (slot.StackSize > 1)
        {
            itemCount.text = slot.StackSize.ToString();
            return;
        }
        itemCount.text = "";
    }

    public void UpdateUISlot_Static(InventorySlot slot)
    {
        UpdateUISlot(slot);
    }

    public void UpdateUISlot()
    {
        if (inventorySlot != null)
        {
            UpdateUISlot(inventorySlot);
        }
    }

    public void ClearSlot()
    {
        inventorySlot?.ClearSlot();
        itemSprite.sprite = null;
        itemSprite.color = Color.clear;
        itemCount.text = "";
    }

    private void OnUISlotClick()
    {
        InvDisplay?.SlotClicked(this);
    }

    public void ToggleHighlight()
    {
        slotHighlight.SetActive(!slotHighlight.activeInHierarchy);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (inventorySlot == null)
        {
            return;
        }

        TooltipManager.ShowToolTip_Static(inventorySlot.ItemData.Description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipManager.HideToolTip_Static();
    }
}

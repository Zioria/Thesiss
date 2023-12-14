using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager Instance;

    [Header("Reference")]
    [SerializeField] private RectTransform tooltipRect;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private RectTransform tooltipHolderRect;
    [SerializeField] private RectTransform canavasRect;

    private void Awake()
    {
        if (Instance != null && Instance == this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        HideToolTip();
    }

    private void Update()
    {
        Vector2 mousePos = Input.mousePosition / canavasRect.localScale.x;
        if (Input.mousePosition.x + tooltipRect.rect.width > canavasRect.rect.width)
        {
            mousePos.x = canavasRect.rect.width - tooltipRect.rect.width;
        }
        if (Input.mousePosition.y + tooltipRect.rect.height > canavasRect.rect.height)
        {
            mousePos.y = canavasRect.rect.height - tooltipRect.rect.height;
        }

        tooltipHolderRect.anchoredPosition = mousePos;
    }

    private void SetText(string message)
    {
        textMeshPro.SetText(message);
        textMeshPro.ForceMeshUpdate();

        Vector2 textSize = textMeshPro.GetRenderedValues(false);
        Vector2 padding = new Vector2(8, 8);

        tooltipRect.sizeDelta = textSize + padding;
    }

    public static void ShowToolTip_Static(string message)
    {
        Instance.ShowToolTip(message);
    }

    private void ShowToolTip(string message)
    {
        tooltipHolderRect.gameObject.SetActive(true);
        SetText(message);
    }

    public static void HideToolTip_Static()
    {
        Instance.HideToolTip();
    }

    private void HideToolTip()
    {
        tooltipHolderRect.gameObject.SetActive(false);
    }
}

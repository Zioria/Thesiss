using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttributeManager : MonoBehaviour
{
    public static AttributeManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    [Tooltip("Current Level Attribute")] public int[] AttributeLevels;
    [Tooltip("Level Cap Attribute")] public int[] AttributeCaps;
    [SerializeField] private GameObject AttributeHolder;
    [SerializeField] private Text pointText;

    public int AttributePoint;
    public List<Attribute> attributeList;

    public int ResetAttributePoint { get; private set; }
    

    private void Start()
    {
        ResetAttributePoint = AttributePoint;

        foreach (var attribute in AttributeHolder.GetComponentsInChildren<Attribute>())
        {
            attributeList.Add(attribute);
        }

        for (int i = 0; i < attributeList.Count; i++)
        {
            attributeList[i].ID = i;
        }

        UpdateAttributeUI();
    }

    public void UpdateAttributeUI()
    {
        pointText.text = "Attribute Points: " + AttributePoint;
        
        foreach (var attribute in attributeList)
        {
            attribute.UpdateUI();
        }
    }

    public void ResetAttributeUI()
    {
        AttributePoint = ResetAttributePoint;
        UpdateAttributeUI();
    }

}

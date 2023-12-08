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
    

    private void Start()
    {
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
        //foreach (var attribute in attributeList)
        //{
        //    attribute.UpdateUI();
        //}
        for (int i = 0; i < attributeList.Count; i++)
        {
            attributeList[i].UpdateUI();
        }
        pointText.text = "Points: " + AttributePoint;
        
    }

}

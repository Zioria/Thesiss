using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AttributeManagerBoy : MonoBehaviour
{
    public static AttributeManagerBoy Instance;
    private void Awake()
    {
        Instance = this;
    }

    [Tooltip("Current Level Attribute")] public int[] AttributeLevels;
    [Tooltip("Level Cap Attribute")] public int[] AttributeCaps;
    [SerializeField] private GameObject AttributeHolder;
    [SerializeField] private TextMeshProUGUI pointText;

    public List<AttributeBoy> attributeList;
    

    private void Start()
    {
        foreach (var attribute in AttributeHolder.GetComponentsInChildren<AttributeBoy>())
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
        pointText.text = AttributePointManager.Instance.Point.ToString();
        
    }

}

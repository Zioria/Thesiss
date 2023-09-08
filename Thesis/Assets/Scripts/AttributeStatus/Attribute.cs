using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static AttributeManager;

public class Attribute : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Button decreaseStatusBtn;
    [SerializeField] private Button increaseStatusBtn;
    [SerializeField] private Text countNumber;

    public int ID;

    private void Awake()
    {
        decreaseStatusBtn.onClick.AddListener(() => {
            DecreaseCharacterStatus();
            DecreaseStatus();
        });
        increaseStatusBtn.onClick.AddListener(() => {
            IncreaseCharacterStatus();
            IncreaseStatus();
        });
    }

    public void UpdateUI()
    {
        countNumber.text = Instance.AttributeLevels[ID].ToString();  
    }

    private void DecreaseStatus()
    {
        if (Instance.AttributeLevels[ID] <= 0)
        {
            return;
        }        
        Instance.AttributeLevels[ID]--;
        Instance.AttributePoint++;
        Instance.UpdateAttributeUI();        
    }
    private void DecreaseCharacterStatus()
    {
        if (Instance.AttributeLevels[ID] == 0)
        {
            return;
        }
        if (ID == 0)
        {
            CharacterStats.Instance.health--;
            CharacterStats.Instance.damage--;
        }
        else if (ID == 1)
        {
            CharacterStats.Instance.atkSpeed--;
            CharacterStats.Instance.armor--;
        }
        else if (ID == 2)
        {
            CharacterStats.Instance.skillDamage--;
            CharacterStats.Instance.capEnergy--;
        }
    }

    private void IncreaseStatus()
    {
        if (Instance.AttributePoint <= 0 || Instance.AttributeLevels[ID] >= Instance.AttributeCaps[ID])
        {
            return;
        }        
        Instance.AttributeLevels[ID]++;
        Instance.AttributePoint--;
        Instance.UpdateAttributeUI();   
    }

    private void IncreaseCharacterStatus()
    {
        if (Instance.AttributePoint <= 0 || Instance.AttributeLevels[ID] >= Instance.AttributeCaps[ID])
        {
            return;
        }
        if (ID == 0)
        {
            CharacterStats.Instance.health++;
            CharacterStats.Instance.damage++;
        }
        else if (ID == 1)
        {
            CharacterStats.Instance.atkSpeed++;
            CharacterStats.Instance.armor++;
        }
        else if (ID ==2)
        {
            CharacterStats.Instance.skillDamage++;
            CharacterStats.Instance.capEnergy++;
        }
    }
}
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
    [SerializeField] private Button ResetStatusBtn;
    [SerializeField] private Text countNumber;
    [SerializeField] private int resetLevel;

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
        ResetStatusBtn.onClick.AddListener(ResetAttriute);
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
            CharacterStats.Instance.MaxHealth--;
            CharacterStats.Instance.Damage--;
        }
        else if (ID == 1)
        {
            CharacterStats.Instance.AtkSpeed--;
            CharacterStats.Instance.Armor--;
        }
        else if (ID == 2)
        {
            CharacterStats.Instance.SkillDamage--;
            CharacterStats.Instance.CapEnergy--;
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
            CharacterStats.Instance.MaxHealth++;
            CharacterStats.Instance.Damage++;
        }
        else if (ID == 1)
        {
            CharacterStats.Instance.AtkSpeed++;
            CharacterStats.Instance.Armor++;
        }
        else if (ID ==2)
        {
            CharacterStats.Instance.SkillDamage++;
            CharacterStats.Instance.CapEnergy++;
        }
    }

    private void ResetAttriute()
    {
        CharacterStats.Instance.ResetStats();
        Instance.ResetAttributeUI();
        Instance.AttributeLevels[ID] = resetLevel;
    }
}
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

    private CharacterStats[] _stats => CharacterStatusUI.Instance.Stats;

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
        foreach (var stat in _stats)
        {
            if (!stat.gameObject.activeInHierarchy)
            {
                continue;
            }
            if (ID == 0)
            {
                stat.MaxHealth--;
                stat.Damage--;
            }
            else if (ID == 1)
            {
                stat.AtkSpeed--;
                stat.Armor--;
            }
            else if (ID == 2)
            {
                stat.SkillDamage--;
                stat.CapEnergy--;
            }
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
        foreach(var stat in _stats)
        {
            if (!stat.gameObject.activeInHierarchy)
            {
                continue;
            }
            if (ID == 0)
            {
                stat.MaxHealth++;
                stat.Damage++;
            }
            else if (ID == 1)
            {
                stat.AtkSpeed++;
                stat.Armor++;
            }
            else if (ID ==2)
            {
                stat.SkillDamage++;
                stat.CapEnergy++;
            }
        }
    }

    private void ResetAttriute()
    {
        
        foreach (var stat in _stats)
        {
            stat.ResetStats();
        }
        Instance.ResetAttributeUI();
        Instance.AttributeLevels[ID] = resetLevel;
    }
}
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static AttributeManagerBoy;

public class AttributeBoy : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Button decreaseStatusBtn;
    [SerializeField] private Button increaseStatusBtn;
    [SerializeField] private TextMeshProUGUI countNumber;
    [SerializeField] private int resetLevel;

    private CharacterStats[] stats => CharacterStatusUI.Instance.Stats;
    private CharacterStats stat;

    public int ID;


    private void Awake()
    {
        decreaseStatusBtn.onClick.AddListener(() =>
        {
            DecreaseCharacterStatus();
            DecreaseStatus();
        });
        increaseStatusBtn.onClick.AddListener(() =>
        {
            IncreaseCharacterStatus();
            IncreaseStatus();
        });
    }

    private void Update()
    {
        stat = CharacterStatusUI.Instance.CurrentActive(stats);
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
        AttributePointManager.Instance.Point++;
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
            stat.MaxHealth--;
            stat.CurrentHealth--;
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
            stat.CurrentCapEnergy--;
        }
    }

    private void IncreaseStatus()
    {
        if (AttributePointManager.Instance.Point <= 0 || Instance.AttributeLevels[ID] >= Instance.AttributeCaps[ID])
        {
            return; 
        }
        Instance.AttributeLevels[ID]++;
        AttributePointManager.Instance.Point--;
        Instance.UpdateAttributeUI();   
    }

    private void IncreaseCharacterStatus()
    {
        if (AttributePointManager.Instance.Point <= 0 || Instance.AttributeLevels[ID] >= Instance.AttributeCaps[ID])
        {
            return;
        }
        if (ID == 0)
        {
            stat.MaxHealth++;
            stat.CurrentHealth++;
            stat.Damage++;
        }
        else if (ID == 1)
        {
            stat.AtkSpeed++;
            stat.Armor++;
        }
        else if (ID == 2)
        {
            stat.SkillDamage++;
            stat.CapEnergy++;
            stat.CurrentCapEnergy++;
        }
    }

    public void IncreaseStatus_Static() => IncreaseStatus();
    public void IncreaseCharacter_Static() => IncreaseCharacterStatus();

    public void DecreaseStatus_Static() => DecreaseStatus();
    public void DecreaseCharacter_Static() => DecreaseCharacterStatus();

    private void ResetAttriute()
    {
        
        foreach (var stat in stats)
        {
            stat.ResetStats();
        }
        //Instance.AttributeLevels[ID] = resetLevel;
        for (int i = 0; i < Instance.attributeList.Count; i++)
        {
            Instance.AttributeLevels[i] = resetLevel;
        }
    }
}
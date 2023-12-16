using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySkill : MonoBehaviour
{
    [SerializeField] private AbilityScriptable ability;
    [Header("UI Setting")]
    [SerializeField] private Button unlockSkillBtn;
    [SerializeField] private CanvasGroup skillUI;
    [SerializeField] private Image skillIcon;

    private AbilityHolder _abilityHolder;
    private CharacterStats[] stats => CharacterStatusUI.Instance.Stats;
    private CharacterStats stat;

    public AbilityScriptable Ability => ability;

    private void Awake()
    {
        _abilityHolder = GameObject.FindGameObjectWithTag("Player").GetComponent<AbilityHolder>();
        unlockSkillBtn.onClick.AddListener(() =>
        {
            stat = CharacterStatusUI.Instance.CurrentActive(stats);
            if (stat.name == "Mc_G")
            {
                UpdateUI();
            }
        });
    }

    private void Update()
    {
         if ((AttributeManagerGirl.Instance.AttributeLevels[0] < 15 || AttributeManagerGirl.Instance.AttributeLevels[2] < 5) && AttributeManagerGirl.Instance.AttributeLevels[1] >= 0)
        {
            skillIcon.sprite = null;
            skillUI.alpha = 0;
            if (_abilityHolder.ability != null)
            {
                _abilityHolder.ability = null;
            }
        }
    } 

    public void UpdateUI()
    {
    
        _abilityHolder.ability = this.ability;

        skillIcon.sprite = ability.IconAbility;
        skillUI.alpha = 1;
        skillUI.interactable = true;
    }
}

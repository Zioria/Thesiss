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
        unlockSkillBtn.onClick.AddListener(() =>
        {
            stat = CharacterStatusUI.Instance.CurrentActive(stats);
            if (stat.name == "Mc_G")
            {
                UpdateUI();
            }
        });
    }

    public void UpdateUI()
    {
        _abilityHolder = GameObject.FindGameObjectWithTag("Player").GetComponent<AbilityHolder>();
        _abilityHolder.ability = this.ability;

        skillIcon.sprite = ability.IconAbility;
        skillUI.alpha = 1;
        skillUI.interactable = true;
    }
}

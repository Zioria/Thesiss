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

    public AbilityScriptable Ability => ability;

    private void Awake()
    {
        unlockSkillBtn.onClick.AddListener(UpdateUI);
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

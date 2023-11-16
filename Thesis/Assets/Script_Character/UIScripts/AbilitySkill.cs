using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySkill : MonoBehaviour
{
    [SerializeField] private AbilityScriptable ability;
    [SerializeField] private Button unlockSkillBtn;
    [SerializeField] private CanvasGroup skillUI;

    private AbilityHolder _abilityHolder;

    public AbilityScriptable Ability => ability;
    public int ID;

    private void Awake()
    {
        unlockSkillBtn.onClick.AddListener(UpdateUI);
    }

    public void UpdateUI()
    {
        _abilityHolder = GameObject.FindGameObjectWithTag("Player").GetComponent<AbilityHolder>();
        _abilityHolder.ability = this.ability;

        skillUI.alpha = 1;
        skillUI.interactable = true;
    }

    public int GetID()
    {
        return ID;
    }

    public AbilityScriptable AbilitySelect(AbilityScriptable select)
    {
        return select;
    }
}

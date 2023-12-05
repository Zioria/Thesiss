using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreeManager : MonoBehaviour
{
    public static SkillTreeManager Instance;

    [SerializeField] private Transform skillTreeHolderUI;
    [SerializeField] private Button skillOneBtn;
    [SerializeField] private Button skillTwoBtn;
    public List<AbilitySkill> abilities;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        foreach (var ability in skillTreeHolderUI.GetComponentsInChildren<AbilitySkill>())
        {
            abilities.Add(ability);
        }

        skillOneBtn.interactable = false;
        skillTwoBtn.interactable = false;
    }

    private void Update()
    {
        if (AttributeManager.Instance.AttributeLevels[0] >= 20 && AttributeManager.Instance.AttributeLevels[1] >= 20 && AttributeManager.Instance.AttributeLevels[2] >= 20)
        {
            skillOneBtn.interactable = true;
        }

        if (AttributeManager.Instance.AttributeLevels[0] >= 15 && AttributeManager.Instance.AttributeLevels[2] >= 5 && AttributeManager.Instance.AttributeLevels[1] >= 0)
        {
            skillTwoBtn.interactable = true;
        }
    }
}

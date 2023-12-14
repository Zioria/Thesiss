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
    [SerializeField] private Image imageSkillOne;
    [SerializeField] private Image imageSkillTwo;

    private Color activeSkillOneColor;
    private Color activeSkillTwoColor;

    private Color inActiveSkillOneColor;
    private Color inActiveSkillTwoColor;

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
        activeSkillOneColor = inActiveSkillOneColor = imageSkillOne.color;
        activeSkillTwoColor = inActiveSkillTwoColor = imageSkillTwo.color;

        activeSkillOneColor.a = 0;
        activeSkillTwoColor.a = 0;
        inActiveSkillOneColor.a = 255;
        inActiveSkillTwoColor.a = 255;

        imageSkillOne.color = inActiveSkillOneColor;
        imageSkillTwo.color = inActiveSkillTwoColor;
    }

    private void Update()
    {
        imageSkillOne.color = inActiveSkillOneColor;
        imageSkillTwo.color = inActiveSkillTwoColor;

        if ((AttributeManagerGirl.Instance.AttributeLevels[0] >= 20 && AttributeManagerGirl.Instance.AttributeLevels[1] >= 20 && AttributeManagerGirl.Instance.AttributeLevels[2] >= 20) ||
            (AttributeManagerBoy.Instance.AttributeLevels[0] >= 20 && AttributeManagerBoy.Instance.AttributeLevels[1] >= 20 && AttributeManagerBoy.Instance.AttributeLevels[2] >= 20))
        {
            skillOneBtn.interactable = true;
            imageSkillOne.color = activeSkillOneColor;
        }

        if (AttributeManagerGirl.Instance.AttributeLevels[0] >= 15 && AttributeManagerGirl.Instance.AttributeLevels[2] >= 5 && AttributeManagerGirl.Instance.AttributeLevels[1] >= 0)
        {
            skillTwoBtn.interactable = true;
            imageSkillTwo.color = activeSkillTwoColor;
        }

    }
}

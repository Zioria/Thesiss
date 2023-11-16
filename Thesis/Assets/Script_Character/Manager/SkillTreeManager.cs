using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeManager : MonoBehaviour
{
    public static SkillTreeManager Instance;

    [SerializeField] private Transform skillTreeHolderUI;
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

        for (int i = 0; i < abilities.Count; i++)
        {
            abilities[i].ID = i;
        }
    }
}

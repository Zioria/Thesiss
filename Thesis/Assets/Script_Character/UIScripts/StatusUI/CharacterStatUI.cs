using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterStatUI : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private StatsScriptable characterStat;
    [SerializeField] private CharacterStats stat;

    [SerializeField]
    private TextMeshProUGUI hpMaxText, hpChangeText, egMaxText,
                                             egChangeText, atkMaxText, atkChangeText, skillMaxText,
                                             skillChangeText;

    private void Start()
    {
        hpMaxText.text = hpChangeText.text = characterStat.DefaultMaxHealth.ToString();
        egMaxText.text = egChangeText.text = characterStat.DefaultCapEnergy.ToString();
        atkMaxText.text = atkChangeText.text = characterStat.DefaultDamage.ToString();
        skillMaxText.text = skillChangeText.text = characterStat.DefaultSkillDamage.ToString() + " %";
    }

    private void Update()
    {
        hpChangeText.text = stat.MaxHealth.ToString();
        atkChangeText.text = stat.Damage.ToString();
        egChangeText.text = stat.CapEnergy.ToString();
        skillChangeText.text = stat.SkillDamage.ToString() + " %";
    }

    private void ConfirmPressed()
    {
        hpMaxText.text = hpChangeText.text = stat.MaxHealth.ToString();
        egMaxText.text = egChangeText.text = stat.CapEnergy.ToString();
        atkMaxText.text = atkChangeText.text = stat.Damage.ToString();
        skillMaxText.text = skillChangeText.text = stat.SkillDamage.ToString() + " %";
    }

    public void ConfirmPressed_Static() => ConfirmPressed();
}

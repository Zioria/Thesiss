using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SlamAbility : AbilityScriptable
{
    private Animator _anim;
    private CharacterStats[] stats => CharacterStatusUI.Instance.Stats;
    private CharacterStats stat;

    public override void Activate()
    {
        stat = CharacterStatusUI.Instance.CurrentActive(stats);
        if (stat.name == "Mc_G")
        {
            _anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
            _anim.SetTrigger("SlamAttack");
            return;
        }

        stat.GetEnergy((int)EnergyUse);
    }

    public override void BeginCooldown()
    {
        if (stat.name == "Mc_G")
        {
            _anim.ResetTrigger("SlamAttack");
        }
    }
}

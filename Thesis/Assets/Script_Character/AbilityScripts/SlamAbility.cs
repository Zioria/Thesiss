using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SlamAbility : AbilityScriptable
{
    private Animator _anim;

    public override void Activate()
    {
        _anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        _anim.SetTrigger("SlamAttack");
    }

    public override void BeginCooldown()
    {
        _anim.ResetTrigger("SlamAttack");
    }
}

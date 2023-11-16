using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityScriptable : ScriptableObject
{
    [SerializeField] private string abilityName;
    [SerializeField] private float coolDownTime;
    [SerializeField] private float activeTime;
    [SerializeField] private Sprite iconAbility;

    public string AbilityName => abilityName;
    public float CoolDownTime => coolDownTime;
    public float ActiveTime => activeTime;
    public Sprite IconAbility => iconAbility;

    public virtual void Activate(TimeManager time) { }
    public virtual void BeginCooldown(TimeManager time) { }
}

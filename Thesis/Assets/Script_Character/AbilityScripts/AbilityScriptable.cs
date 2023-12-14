using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityScriptable : ScriptableObject
{
    [SerializeField] private string abilityName;
    [SerializeField] private float coolDownTime;
    [SerializeField] private float activeTime;
    [SerializeField] private float energyUse;
    [SerializeField] private Sprite iconAbility;

    public string AbilityName => abilityName;
    public float CoolDownTime => coolDownTime;
    public float ActiveTime => activeTime;
    public float EnergyUse => energyUse;
    public Sprite IconAbility => iconAbility;

    public virtual void Activate() { }
    public virtual void BeginCooldown() { }
}

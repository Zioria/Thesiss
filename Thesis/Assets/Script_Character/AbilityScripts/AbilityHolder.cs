using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public AbilityScriptable ability = null;
    [SerializeField] private KeyCode keyCode;

    private CharacterStats[] _stats => CharacterStatusUI.Instance.Stats;
    private CharacterStats _stat;
    private float _coolDownTime;
    private float _activeTime;

    public AbilityState state = AbilityState.ready;

    void Update()
    {
        if (ability == null)
        {
            return;
        }
        switch (state)
        {
            case AbilityState.ready:
                if (Input.GetKeyDown(keyCode))
                {
                    _stat = CharacterStatusUI.Instance.CurrentActive(_stats);
                    if (_stat.CurrentCapEnergy < ability.EnergyUse)
                    {
                        return;
                    }
                    _stat.EnergyUse((int)ability.EnergyUse);
                    ability.Activate();
                    state = AbilityState.active;
                    _activeTime = ability.ActiveTime;
                }
                break;
            case AbilityState.active:
                if (_activeTime > 0)
                {
                    _activeTime -= Time.deltaTime;
                    return;
                }
                ability.BeginCooldown();
                state = AbilityState.cooldown;
                _coolDownTime = ability.CoolDownTime;
                break;
            case AbilityState.cooldown:
                if (_coolDownTime > 0)
                {
                    _coolDownTime -= Time.deltaTime;
                    return;
                }
                state = AbilityState.ready;
                break;
        }
    }
}

public enum AbilityState
{
    ready,
    active,
    cooldown
}

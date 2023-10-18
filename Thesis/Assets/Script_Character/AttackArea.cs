
using System;
using System.Collections.Generic;
using Script_Character.Interface;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public List<IDamagable> Damageables { get; } = new();

    public void OnTriggerEnter(Collider other)
    {
        var damagable = other.GetComponent<IDamagable>();
        if (damagable != null)
        {
            Damageables.Add(damagable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var damageble = other.GetComponent<IDamagable>();
        if (damageble != null && Damageables.Contains(damageble))
        {
            Damageables.Remove(damageble);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterStatusUI;

public class DamageScript : MonoBehaviour
{
    [SerializeField] private int damageAmount;

    private CharacterStats[] stats => Instance.Stats;
    private CharacterStats stat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DamageObject(damageAmount);
        }
    }

    private void DamageObject(int damage)
    {
        stat = Instance.CurrentActive(stats);

        stat.TakeDamage(damage);
    }
}

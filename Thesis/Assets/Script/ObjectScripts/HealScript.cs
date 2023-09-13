using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CharacterStatusUI;

public class HealScript : MonoBehaviour
{
    [SerializeField] private int healAmount;

    private CharacterStats[] stats => Instance.Stats;
    private CharacterStats stat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealObject(healAmount);
        }
    }

    private void HealObject(int amount)
    {
        stat = Instance.CurrentActive(stats);

        stat.HealDamage(amount);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private StatsEnemyScriptable _enemyStat;
    private CharacterStats[] _stats => CharacterStatusUI.Instance.Stats;
    private CharacterStats _stat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _stat = CharacterStatusUI.Instance.CurrentActive(_stats);
            _stat.TakeDamage(_enemyStat.MaxAttack);
        }
    }
}

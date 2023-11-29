using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private CharacterStats[] _stats => CharacterStatusUI.Instance.Stats;
    private CharacterStats _stat;
    private StatsEnemyScriptable _enemyStat;

    private void Start()
    {
        _enemyStat = GetComponentInParent<EnemyStat>().Stat;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _stat = CharacterStatusUI.Instance.CurrentActive(_stats);
            _stat.TakeDamage(_enemyStat.MaxAttack);
        }
    }
}

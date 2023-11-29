using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private StatsEnemyScriptable enemyStat;

    private CharacterStats[] _stats => CharacterStatusUI.Instance.Stats;
    private CharacterStats _stat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _stat = CharacterStatusUI.Instance.CurrentActive(_stats);
            _stat.TakeDamage(enemyStat.MaxAttack);
        }
    }

    private void LateUpdate()
    {
        transform.position += transform.up * bulletSpeed * Time.deltaTime;
    }
}

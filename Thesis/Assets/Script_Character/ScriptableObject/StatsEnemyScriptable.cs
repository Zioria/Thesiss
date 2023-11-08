using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStat", menuName = "ScriptableObject/EnemyStat")]
public class StatsEnemyScriptable : ScriptableObject
{
    [Header("Stat Enemy Setting")]
    [SerializeField] private float maxHealth;

    public float MaxHealth => maxHealth;
}

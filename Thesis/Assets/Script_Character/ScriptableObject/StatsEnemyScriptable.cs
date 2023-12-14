using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStat", menuName = "ScriptableObject/EnemyStat")]
public class StatsEnemyScriptable : ScriptableObject
{
    [Header("Stat Enemy Setting")]
    [SerializeField] private float maxHealth;
    [SerializeField] private float maxAttack;

    public float MaxHealth => maxHealth;
    public float MaxAttack => maxAttack;
}

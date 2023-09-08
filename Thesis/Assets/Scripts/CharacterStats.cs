using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [Header("Status Strength")]
    public int health;
    public int damage;

    [Header("Status Agility")]
    public float atkSpeed;
    public int armor;

    [Header("Status Technology")]
    public float skillDamage;
    public int capEnergy;

    public static CharacterStats Instance;

    private void Awake()
    {
        Instance = this;
    }
}

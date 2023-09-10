using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [Header("Status Strength")]
    public int MaxHealth;
    public int damage;

    [Header("Status Agility")]
    public float atkSpeed;
    public int armor;

    [Header("Status Technology")]
    public float skillDamage;
    public int capEnergy;

    public static CharacterStats Instance;

    public int CurrentHealth { get; private set; }
    private int _currentDamage;
    private float _currentAtkSpeed;
    private int _currentArmor;
    private float _currentSkillDamage;
    private int _currentCapEnergy;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }
    private void Update()
    {
        Debug.Log(CurrentHealth);
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
    }
}

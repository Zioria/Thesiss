using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public static CharacterStats Instance;

    [SerializeField] private StatsScriptable statsScriptable;

    public int CurrentHealth;
    public int CurrentArmor { get; private set; }
    public int CurrentCapEnergy { get; private set; }

    public int MaxHealth;
    public int Damage;
    public int AtkSpeed;
    public int Armor;
    public int SkillDamage;
    public int CapEnergy;

    private bool _isRunOneTime;

    private void Awake()
    {
        Instance = this;

        if (_isRunOneTime)
        {
            return;
        }
        Initialize();
        _isRunOneTime = true;
    }

    private void Update()
    {
        //Debug.Log(_isRunOneTime);
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
    }

    public void HealDamage(int amount)
    {
        CurrentHealth += amount;
        if (CurrentHealth >= MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
    }

    private void Initialize()
    {
        MaxHealth = statsScriptable.defaultMaxHealth;
        Damage = statsScriptable.DefaultDamage;
        AtkSpeed = statsScriptable.DefaultAtkSpeed;
        Armor = statsScriptable.DefaultArmor;
        SkillDamage = statsScriptable.DefaultSkillDamage;
        CapEnergy = statsScriptable.DefaultCapEnergy;

        CurrentHealth = MaxHealth;
        CurrentArmor = Armor;
        CurrentCapEnergy = CapEnergy;
    }

    public void ResetStats()
    {
        int tempHealth = CurrentHealth;
        Initialize();
        if (tempHealth < MaxHealth)
        {
            CurrentHealth = tempHealth;
        }
    }
}

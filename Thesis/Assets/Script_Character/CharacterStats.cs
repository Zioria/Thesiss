using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public static CharacterStats Instance;
    public GameObject Model_G;
    public GameObject Model_M;
    public SwapChar _swapchar;
    

    [SerializeField] private StatsScriptable statsScriptable;

    public int CurrentHealth;
    public int CurrentArmor { get; private set; }
    public int CurrentCapEnergy;

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
        

        _swapchar = GameObject.Find("Player").GetComponent<SwapChar>();
        
        if (_isRunOneTime)
        {
            return;
        }
        Initialize();
        _isRunOneTime = true;
    }

    public void EnergyUse(int energy)
    {
        CurrentCapEnergy -= energy;
        if (CurrentCapEnergy <= 0)
        {
            CurrentCapEnergy = 0;
        }
    }

    public void GetEnergy(int energy)
    {
        CurrentCapEnergy += energy;
        if (CurrentCapEnergy >= CapEnergy)
        {
            CurrentCapEnergy = CapEnergy;
        }
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= (int)damage;
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

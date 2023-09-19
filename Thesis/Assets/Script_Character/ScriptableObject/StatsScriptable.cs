using UnityEngine;


[CreateAssetMenu(fileName = "StatsCharacter", menuName = "ScriptableObject/Stats")]
public class StatsScriptable : ScriptableObject
{
    [Header("Status Strength")]

    [Range(1, 100)] public int defaultMaxHealth;
    [SerializeField] private int defaultDamage;

    public int DefaultMaxHealth => defaultMaxHealth;
    public int DefaultDamage => defaultDamage;

    [Header("Status Agility")]

    [SerializeField] private int defaultAtkSpeed;
    [SerializeField] private int defaultArmor;

    public int DefaultAtkSpeed => defaultAtkSpeed;
    public int DefaultArmor => defaultArmor;

    [Header("Status Technology")]

    [SerializeField] private int defaultSkillDamage;
    [SerializeField] private int defaultCapEnergy;

    public int DefaultSkillDamage => defaultSkillDamage;
    public int DefaultCapEnergy => defaultCapEnergy;
}

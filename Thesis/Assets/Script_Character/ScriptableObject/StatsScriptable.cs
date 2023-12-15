using UnityEngine;


[CreateAssetMenu(fileName = "StatsCharacter", menuName = "ScriptableObject/CharacterStat")]
public class StatsScriptable : ScriptableObject
{
    [Header("Setting Character")]
    [SerializeField] private string nameCharacter;
    [SerializeField] private Sprite iconCharacter;

    public string NameCharacter => nameCharacter;
    public Sprite IconCharacter => iconCharacter;

    [Header("Status Strength")]

    [Range(1, 100)] [SerializeField] private int defaultMaxHealth;
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

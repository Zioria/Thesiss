using System;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/Items")]
public class ItemScriptable : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private string displayName;
    [SerializeField] private int numberGet;
    [SerializeField, TextArea(4, 4)] private string description;
    [SerializeField] private Sprite iconItem;
    [SerializeField] private int maxStackSize;
    [SerializeField] private GameObject itemPrefab;

    public int ID => id;
    public string DisplayName => displayName;
    public int NumberGet => numberGet;
    public string Description => description;
    public Sprite IconItem => iconItem;
    public int MaxStackSize => maxStackSize;
    public GameObject ItemPrefab => itemPrefab;

    private CharacterStats[] _stats => CharacterStatusUI.Instance.Stats;
    private CharacterStats _stat;

    public void UseItem()
    {
        _stat = CharacterStatusUI.Instance.CurrentActive(_stats);
        switch (id)
        {
            case 0 :
                _stat.HealDamage(numberGet);
                break;
            case 1:
                AttributeManager.Instance.AttributePoint += numberGet;
                AttributeManager.Instance.UpdateAttributeUI();
                break;
            case 2:
                _stat.GetEnergy(numberGet);
                break;
            case 3:
                
                break;
        }
    }
}

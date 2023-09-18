using UnityEngine;


[CreateAssetMenu(fileName = "Name Item" , menuName = "ScriptableObject/Items")]
public class ItemScriptable : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private string itemName;
    [SerializeField] private int value;
    [SerializeField] private Sprite iconImage;

    public int ID => id;
    public string ItemName => itemName;
    public int Value => value;
    public Sprite IconImage => iconImage;
}

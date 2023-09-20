using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    //public int Str;
    //public int Agi;
    //public int Tec;
    public int AtbPoint;
    public int gold;

    public PlayerData (Player player)
    {
      // Str = AttributeManager.Instance.AttributeLevels[0];
      // Agi = AttributeManager.Instance.AttributeLevels[1];
      // Tec = AttributeManager.Instance.AttributeLevels[2];
       AtbPoint = AttributeManager.Instance.AttributePoint;
       gold = player.gold;
    }
}

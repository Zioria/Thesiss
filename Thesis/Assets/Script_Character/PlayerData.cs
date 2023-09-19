using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    
    public int AttributePoint;
    public int gold;

    public PlayerData (Player player)
    {
       AttributePoint = player.AttributePoint;
       gold = player.gold;
    }
}

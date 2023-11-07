using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    //public int ID;
    public int AtbPoint;
    public int gold;
    
    public PlayerData (Player player)
    {

       //ID =  AttributeManager.Instance.AttributeLevels[ID];
       //AttributeManager.Instance.ResetAttributeUI();
       //AttributeManager.Instance.UpdateAttributeUI();
       AtbPoint = player.AtbPoint;
       gold = player.gold;
    }

  
}

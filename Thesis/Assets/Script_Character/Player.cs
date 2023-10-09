using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public static Player Instance;  
   public int hp;
   public int AtbPoint;
   public int gold;

   public Quest quest;

   public void SavePlayer ()
   {
        Debug.Log("Save completed!");
        Savesystem.SavePlayer(this);
   }

   public void LoadPlayer ()
   {
        Debug.Log("LoadSave completed!");
        PlayerData data = Savesystem.LoadPlayer();

        AtbPoint = data.AtbPoint;
        gold = data.gold;

   }

   public void Awake()
   {
      Instance = this;
   }

   public void GoBattle()
   {
        
        gold += 5;
        
        if (quest.isActive)
        {
            quest.goal.EnemyKilled();
            if (quest.goal.IsReached())
            {
                AtbPoint += quest.AttributePointReward;
                AttributeManager.Instance.AttributePoint += quest.AttributePointReward;
                AttributeManager.Instance.ResetAttributePoint += quest.AttributePointReward;
                AttributeManager.Instance.UpdateAttributeUI();
                
                gold += quest.goldReward;
                quest.Complete();
            }
        }
   }


}

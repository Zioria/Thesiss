using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public int hp;
   public int AttributePoint;
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

        AttributePoint = data.AttributePoint;
        gold = data.gold;

   }

   public void GoBattle(AttributeManager AttributePoint)
   {
        
        gold += 5;

        if (quest.isActive)
        {
            quest.goal.EnemyKilled();
            if (quest.goal.IsReached())
            {
                //AttributePoint += quest.AttributePointReward;
                gold += quest.goldReward;
                quest.Complete();
            }
        }
   }


}

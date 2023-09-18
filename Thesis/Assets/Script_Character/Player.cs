using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public int hp = 100;
   public int exp = 50;
   public int gold = 1000;

   public Quest quest;

   public void GoBattle()
   {
    
        hp -= 5;
        exp += 5;
        gold += 5;

        if (quest.isActive)
        {
            quest.goal.EnemyKilled();
            if (quest.goal.IsReached())
            {
                exp += quest.expReward;
                gold += quest.goldReward;
                quest.Complete();
            }
        }
   }
}

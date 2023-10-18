using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest 
{
    public static Quest Instance;
    public bool isActive;

    public string title;
    public string description;
    public int goldReward;
    public int AttributePointReward;

    public QuestGoal goal;
    

   public void Awake()
   {
      Instance = this;
   }

    public void Complete()
    {
        isActive = false;
        Debug.Log(title + " was completed!");
    }
}

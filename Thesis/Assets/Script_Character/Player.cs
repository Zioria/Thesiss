using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
   public static Player Instance;

   
   //public Text playerName;
   //public Datamanager datamanager;

   //public int hp;
   public int AtbPoint;
   public int gold;
   public Text golddisplay;

   public GameObject questB;
   public GameObject UIq1;
   public GameObject UIq2;
   public GameObject UIq3;

   public GameObject questBD;
   public GameObject UIq1D;
   public GameObject UIq2D;
   public GameObject UIq3D;

   public Quest quest;
   
   

   void Start()
   {
       // datamanager.Load();
        //playerName.text = datamanager.data.name; 
        //gold = datamanager.data.gold1;
   }

   public void SaveFile()
   {
       // datamanager.Save();
   }

   //public void LoadFile()
  // {
       // datamanager.Load();
  // }


   public void ChangeName(string text)
   {
       //datamanager.data.name = text;
   }

   public void Awake()
   {
      Instance = this;
      //AttributeManager.Instance.UpdateAttributeUI();
   }

   private void Update()
   {
        //AttributeManager.Instance.ResetAttributeUI();
        //AttributeManager.Instance.UpdateAttributeUI();
        golddisplay.text = gold.ToString();
        AtbPoint = AttributeManager.Instance.AttributePoint;
   }

   public void GoBattle()
   {
     
        gold += 10;
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
                questB.SetActive(false);
                UIq1.SetActive(false);
                UIq2.SetActive(false);
                UIq3.SetActive(false);

                questBD.SetActive(false);
                UIq1D.SetActive(false);
                UIq2D.SetActive(false);
                UIq3D.SetActive(false);
                

            }
        }
   }  

   

}

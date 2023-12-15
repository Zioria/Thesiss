using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Player : MonoBehaviour
{
   public static Player Instance;

   
   //public Text playerName;
   //public Datamanager datamanager;

   //public int hp;
   public int AtbPoint;
   public int gold;
   public  TMP_Text golddisplay;
   public int Countcurrent;
   public Text CountcurrentQ1;
   public Text CountcurrentQ2;
   public Text CountcurrentQ3;
   public Text CountcurrentQ4;
   public Text CountcurrentQ5;
   public Text CountcurrentQ6;

   public GameObject questB;
   public GameObject questBDIS;
   public GameObject UIq1;
   public GameObject UIq2;
   public GameObject UIq3;

   public GameObject questBD;
   public GameObject questBDIS2;
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


  // public void ChangeName(string text)
  // {
       //datamanager.data.name = text;
  // }

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
        CountcurrentQ1.text = Countcurrent.ToString();
        CountcurrentQ2.text = Countcurrent.ToString();
        CountcurrentQ3.text = Countcurrent.ToString();
        CountcurrentQ4.text = Countcurrent.ToString();
        CountcurrentQ5.text = Countcurrent.ToString();
        CountcurrentQ6.text = Countcurrent.ToString();
        CountcurrentQ1.text =  Countcurrent + " / 1 ";
        CountcurrentQ2.text =  Countcurrent + " / 5 ";
        CountcurrentQ3.text =  Countcurrent + " / 10 ";
        CountcurrentQ4.text =  Countcurrent + " / 5 ";
        CountcurrentQ5.text =  Countcurrent + " / 8 ";
        CountcurrentQ6.text =  Countcurrent + " / 15 ";

        AtbPoint = AttributeManager.Instance.AttributePoint;
   }

   public void GoBattle()
   {
     
        //gold += 10;
        if (quest.isActive)
        {
            quest.goal.EnemyKilled();
            if (quest.goal.IsReached())
            {
                
                AtbPoint += quest.AttributePointReward;
                AttributeManager.Instance.AttributePoint += quest.AttributePointReward;
                AttributeManager.Instance.UpdateAttributeUI();
                
                gold += quest.goldReward;
                quest.Complete();
                questB.SetActive(true);
                questBDIS.SetActive(false);
                UIq1.SetActive(false);
                UIq2.SetActive(false);
                UIq3.SetActive(false);

                questBD.SetActive(true);
                questBDIS2.SetActive(false);
                UIq1D.SetActive(false);
                UIq2D.SetActive(false);
                UIq3D.SetActive(false);

                Countcurrent = 0;
                GetComponent<Shortcutscript>().enabled = true;
                

            }
        }
   }  

   

}

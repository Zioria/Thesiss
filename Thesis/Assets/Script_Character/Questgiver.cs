using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Questgiver : MonoBehaviour
{   
    public static Questgiver Instance;
    public GameObject headQ1;
    public GameObject headQ2;
    public GameObject headQ3;
    public GameObject headQ11;
    public GameObject headQ22;
    public GameObject headQ33;
    public GameObject CloseQuest;
    public GameObject ButtonCloseQuest;
    public GameObject UIquest1;
    public GameObject UIquest2;
    public GameObject UIquest3;
    public GameObject questB;
    public GameObject questDis1;
    public GameObject questDis2;
    public GameObject questDis3;

    public Quest quest1;
    public Player player;
    public GameObject questUI;
    public Text title;
    public Text description;
    public Text AttributePoint;
    public Text gold;
    public Text titleUI1;
    public Text descriptionUI1;
    
    public Quest quest2;
    public Player player2;
    public GameObject questUI2;
    public Text title2;
    public Text description2;
    public Text AttributePoint2;
    public Text gold2;
    public Text titleUI2;
    public Text descriptionUI2;
    

    public Quest quest3;
    public Player player3;
    public GameObject questUI3;
    public Text title3;
    public Text description3;
    public Text AttributePoint3;
    public Text gold3;
    public Text titleUI3;
    public Text descriptionUI3;
    

   

    public void Start()
    {
        headQ11.SetActive(false);
        headQ22.SetActive(false);
        headQ33.SetActive(false);
        CloseQuest.SetActive(false);
        ButtonCloseQuest.SetActive(true);
        UIquest1.SetActive(false);
        UIquest2.SetActive(false);
        UIquest3.SetActive(false);
        questUI.SetActive(false);
        questUI2.SetActive(false);
        questUI3.SetActive(false);
        questDis1.SetActive(false);
        questDis2.SetActive(false);
        questDis3.SetActive(false);
    }

    public void OpenCQuestWindow()
    {
        CloseQuest.SetActive(true);
    }

     public void CloseCQuestWindow()
    {
        CloseQuest.SetActive(false);
    }

    public void OpenH1QuestWindow()
    {
       headQ1.SetActive(false);
       headQ11.SetActive(true);
    }
    public void OpenH2QuestWindow()
    {
        headQ2.SetActive(false);
        headQ22.SetActive(true);
    }
    public void OpenH3QuestWindow()
    {
        headQ3.SetActive(false);
        headQ33.SetActive(true);
    }

    public void OpenH11QuestWindow()
    {
       headQ1.SetActive(true);
       headQ11.SetActive(false);
    }
    public void OpenH22QuestWindow()
    {
        headQ2.SetActive(true);
        headQ22.SetActive(false);
    }
    public void OpenH33QuestWindow()
    {
        headQ3.SetActive(true);
        headQ33.SetActive(false);
    }


    public void OpenQuestWindow1()
    {
        questUI.SetActive(true);
        CloseQuest.SetActive(true);
        title.text = quest1.title;
        description.text = quest1.description;
        AttributePoint.text = quest1.AttributePointReward.ToString();
        gold.text = quest1.goldReward.ToString();
        titleUI1.text = quest1.title;
        descriptionUI1.text = quest1.description;
       
        
    }

     public void CloseQuestWindow1()
    {
        //CloseQuest.SetActive(false);
        //ButtonCloseQuest.SetActive(false);
        questUI.SetActive(false);
        title.text = quest1.title;
        description.text = quest1.description;
        AttributePoint.text = quest1.AttributePointReward.ToString();
        gold.text = quest1.goldReward.ToString();
        titleUI1.text = quest1.title;
        descriptionUI1.text = quest1.description;
       

    }

    public void AcceptQuest1()
    {
        questUI.SetActive(false);
        questUI2.SetActive(false);
        questUI3.SetActive(false);
        CloseQuest.SetActive(false);
        //ButtonCloseQuest.SetActive(false);
        questB.SetActive(false);
        questDis1.SetActive(true);
        UIquest1.SetActive(true);
        quest1.isActive = true;
        player.quest = quest1;
        //PlayerInput = 
        //GetComponent<Shortcutscript>().enabled = false;
    }
   
    public void OpenQuestWindow2()
    {
        questUI2.SetActive(true);
        title2.text = quest2.title;
        description2.text = quest2.description;
        AttributePoint2.text = quest2.AttributePointReward.ToString();
        gold2.text = quest2.goldReward.ToString();
        titleUI2.text = quest2.title;
        descriptionUI2.text = quest2.description;
       

    }

    public void CloseQuestWindow2()
    {
        questUI2.SetActive(false);
        title2.text = quest2.title;
        description2.text = quest2.description;
        AttributePoint2.text = quest2.AttributePointReward.ToString();
        gold2.text = quest2.goldReward.ToString();
        titleUI2.text = quest2.title;
        descriptionUI2.text = quest2.description;
        
    }

    public void AcceptQuest2()
    {
        questUI.SetActive(false);
        questUI2.SetActive(false);
        questUI3.SetActive(false);
        CloseQuest.SetActive(false);
        //ButtonCloseQuest.SetActive(false);
        questB.SetActive(false);
        questDis2.SetActive(true);
        UIquest2.SetActive(true);
        quest2.isActive = true;
        player.quest = quest2;
        //GetComponent<Shortcutscript>().enabled = false;
    }

    public void OpenQuestWindow3()
    {
        questUI3.SetActive(true);
        title3.text = quest3.title;
        description3.text = quest3.description;
        AttributePoint3.text = quest3.AttributePointReward.ToString();
        gold3.text = quest3.goldReward.ToString();
        titleUI3.text = quest3.title;
        descriptionUI3.text = quest3.description;
       
    }

     public void CloseQuestWindow3()
    {
        questUI3.SetActive(false);
        title3.text = quest3.title;
        description3.text = quest3.description;
        AttributePoint3.text = quest3.AttributePointReward.ToString();
        gold3.text = quest3.goldReward.ToString();
        titleUI3.text = quest3.title;
        descriptionUI3.text = quest3.description;
        
    }

    public void AcceptQuest3()
    {
        questUI.SetActive(false);
        questUI2.SetActive(false);
        questUI3.SetActive(false);
        CloseQuest.SetActive(false);
        //ButtonCloseQuest.SetActive(false);
        questB.SetActive(false);
        questDis3.SetActive(true);
        UIquest3.SetActive(true);
        quest3.isActive = true;
        player.quest = quest3;
        //GetComponent<Shortcutscript>() = false;
    }
   
}

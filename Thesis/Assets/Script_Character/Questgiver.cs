using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Questgiver : MonoBehaviour
{   
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

    public Quest quest2;
    public Player player2;
    public GameObject questUI2;
    public Text title2;
    public Text description2;
    public Text AttributePoint2;
    public Text gold2;

    public Quest quest3;
    public Player player3;
    public GameObject questUI3;
    public Text title3;
    public Text description3;
    public Text AttributePoint3;
    public Text gold3;

   

    public void Start()
    {
        questUI.SetActive(false);
        questUI2.SetActive(false);
        questUI3.SetActive(false);
        questB.SetActive(false);
        questDis1.SetActive(false);
        questDis2.SetActive(false);
        questDis3.SetActive(false);
    }

    public void OpenQuestWindow1()
    {
        questUI.SetActive(true);
        title.text = quest1.title;
        description.text = quest1.description;
        AttributePoint.text = quest1.AttributePointReward.ToString();
        gold.text = quest1.goldReward.ToString();
    }

     public void CloseQuestWindow1()
    {
        questUI.SetActive(false);
        title.text = quest1.title;
        description.text = quest1.description;
        AttributePoint.text = quest1.AttributePointReward.ToString();
        gold.text = quest1.goldReward.ToString();
    }

    public void AcceptQuest1()
    {
        questUI.SetActive(false);
        questUI2.SetActive(false);
        questUI3.SetActive(false);
        questB.SetActive(true);
        questDis1.SetActive(true);
        quest1.isActive = true;
        player.quest = quest1;
    }
   
    public void OpenQuestWindow2()
    {
        questUI2.SetActive(true);
        title2.text = quest2.title;
        description2.text = quest2.description;
        AttributePoint2.text = quest2.AttributePointReward.ToString();
        gold2.text = quest2.goldReward.ToString();
    }

    public void CloseQuestWindow2()
    {
        questUI.SetActive(false);
        title2.text = quest2.title;
        description2.text = quest2.description;
        AttributePoint2.text = quest2.AttributePointReward.ToString();
        gold2.text = quest2.goldReward.ToString();
    }

    public void AcceptQuest2()
    {
        questUI.SetActive(false);
        questUI2.SetActive(false);
        questUI3.SetActive(false);
        questB.SetActive(true);
        questDis2.SetActive(true);
        quest2.isActive = true;
        player.quest = quest2;
    }

    public void OpenQuestWindow3()
    {
        questUI3.SetActive(true);
        title3.text = quest3.title;
        description3.text = quest3.description;
        AttributePoint3.text = quest3.AttributePointReward.ToString();
        gold3.text = quest3.goldReward.ToString();
    }

     public void CloseQuestWindow3()
    {
        questUI3.SetActive(false);
        title3.text = quest3.title;
        description3.text = quest3.description;
        AttributePoint3.text = quest3.AttributePointReward.ToString();
        gold3.text = quest3.goldReward.ToString();
    }

    public void AcceptQuest3()
    {
        questUI.SetActive(false);
        questUI2.SetActive(false);
        questUI3.SetActive(false);
        questB.SetActive(true);
        questDis3.SetActive(true);
        quest3.isActive = true;
        player.quest = quest3;
    }
   
}

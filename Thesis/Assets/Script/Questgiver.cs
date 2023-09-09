using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Questgiver : MonoBehaviour
{
    public Quest quest;

    public Player player;

    public GameObject questUI;
    public Text title;
    public Text description;
    public Text exp;
    public Text gold;

    public void Start()
    {
        questUI.SetActive(false);
    }

    public void OpenQuestWindow()
    {
        questUI.SetActive(true);
        title.text = quest.title;
        description.text = quest.description;
        exp.text = quest.expReward.ToString();
        gold.text = quest.goldReward.ToString();
    }

     public void CloseQuestWindow()
    {
        questUI.SetActive(false);
        title.text = quest.title;
        description.text = quest.description;
        exp.text = quest.expReward.ToString();
        gold.text = quest.goldReward.ToString();
    }

    public void AcceptQuest()
    {
        questUI.SetActive(false);
        quest.isActive = true;
        player.quest = quest;
    }

}

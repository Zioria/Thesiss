using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Displayplayer : MonoBehaviour
{
    public Player player;

    public Text hpdisplay;
    public Text AttributePointdisplay;
    public Text golddisplay;

    public void Update()
    {
        hpdisplay.text = player.hp.ToString();
        AttributePointdisplay.text = player.AttributePoint.ToString();
        golddisplay.text = player.gold.ToString();
    }
}

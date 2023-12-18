using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoUI : MonoBehaviour
{
    [SerializeField] private GameObject infoHoleder;
    [SerializeField] private GameObject popup1Open;
    [SerializeField] private GameObject popup1Close;
    [SerializeField] private GameObject popup2Open;
    [SerializeField] private GameObject popup2Close;
    [SerializeField] private GameObject popup3Open;
    [SerializeField] private GameObject popup3Close;
    [SerializeField] private GameObject popup4Open;
    [SerializeField] private GameObject popup4Close;
    [SerializeField] private GameObject popup5Open;
    [SerializeField] private GameObject popup5Close;

    [SerializeField] private GameObject info1;
    [SerializeField] private GameObject info2;
    [SerializeField] private GameObject info3;
    [SerializeField] private GameObject info4;
    [SerializeField] private GameObject info5;

    private void Start()
    {
        infoHoleder.SetActive(true);
        if (infoHoleder.activeInHierarchy)
        {
            Time.timeScale = 0;
        }
        else if(infoHoleder.activeInHierarchy == false)
        {
            Time.timeScale = 1;
        }

    }

    //InfoPaused 
    public void OpenInfo()
    {
        infoHoleder.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void CloseGameInfo()
    {
        infoHoleder.SetActive(false);

        Time.timeScale = 1;
    }

    public void Open1()
    {
       info1.SetActive(true);
       popup1Open.SetActive(false);
       popup1Close.SetActive(true);
    }

    public void Close1()
    {
       info1.SetActive(false);
       popup1Open.SetActive(true);
       popup1Close.SetActive(false);
    }

    public void Open2()
    {
       info2.SetActive(true);
       popup2Open.SetActive(false);
       popup2Close.SetActive(true);
    }

    public void Close2()
    {
       info2.SetActive(false);
       popup2Open.SetActive(true);
       popup2Close.SetActive(false);
    }

    public void Open3()
    {
       info3.SetActive(true);
       popup3Open.SetActive(false);
       popup3Close.SetActive(true);
    }

    public void Close3()
    {
       info3.SetActive(false);
       popup3Open.SetActive(true);
       popup3Close.SetActive(false);
    }

    public void Open4()
    {
       info4.SetActive(true);
       popup4Open.SetActive(false);
       popup4Close.SetActive(true);
    }

    public void Close4()
    {
       info4.SetActive(false);
       popup4Open.SetActive(true);
       popup4Close.SetActive(false);
    }

    public void Open5()
    {
       info5.SetActive(true);
       popup5Open.SetActive(false);
       popup5Close.SetActive(true);
    }

    public void Close5()
    {
       info5.SetActive(false);
       popup5Open.SetActive(true);
       popup5Close.SetActive(false);
    }

}

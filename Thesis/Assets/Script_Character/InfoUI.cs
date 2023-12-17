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

    [SerializeField] private GameObject info1;
    [SerializeField] private GameObject info2;
    [SerializeField] private GameObject info3;
    [SerializeField] private GameObject info4;
    

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

    private void Awake()
    {
       
        Time.timeScale = 1;
    }

    //InfoPaused 
    public void PauseGameInfo()
    {
        infoHoleder.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void UnPauseGameInfo()
    {
        infoHoleder.SetActive(false);

        Time.timeScale = 1;
    }

    public void Open1()
    {

    }

    public void Close1()
    {
        
    }

    public void Open2()
    {

    }

    public void Close2()
    {
        
    }

    public void Open3()
    {

    }

    public void Close3()
    {
        
    }

    public void Open4()
    {

    }

    public void Close4()
    {
        
    }

}

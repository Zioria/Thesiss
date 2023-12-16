using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoUI : MonoBehaviour
{
    [SerializeField] private GameObject infoHoleder;
    //[SerializeField] private GameObject Tutorial;

    public float waitOpen;
    
    
    

    private void Start()
    {
        //StartCoroutine(WaitTime());
        
        if (infoHoleder.activeInHierarchy)
        {
            
            Time.timeScale = 0;
        }
        else if(infoHoleder.activeInHierarchy == false)
        {
            Time.timeScale = 1;
        }

    }

    public void No()
    {
        //Tutorial.SetActive(false);

    }

    private void Awake()
    {
        infoHoleder.SetActive(false);
        Time.timeScale = 1;
    }

    //InfoPaused 
    public void PauseGameInfo()
    {
        infoHoleder.SetActive(true);
        //Tutorial.SetActive(false);
        Time.timeScale = 0;
    }
    
    public void UnPauseGameInfo()
    {
        infoHoleder.SetActive(false);

        Time.timeScale = 1;
    }

    //IEnumerator WaitTime()
   // {
       // yield return new  WaitForSeconds(waitOpen);
      //  Tutorial.SetActive(true);
        
   // }
}

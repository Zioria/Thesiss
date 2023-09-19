using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapChar : MonoBehaviour
{
    [Header("Character")]
    public GameObject mc_g;
    public GameObject mc_m;

    [Header("CheckControl")] 
    public int addnumber_g = 1;
    public int addnumber_m = 2;
    
    public KeyCode[] anyKey;

    private void Start()
    {
        
        mc_g.SetActive(true);
        mc_m.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(anyKey[0]))
        {
            mc_m.SetActive(false);
            mc_g.SetActive(true);
        }
        else if (Input.GetKeyDown(anyKey[1]))
        {
            mc_g.SetActive(false);
            mc_m.SetActive(true);
        }

        
    }
}

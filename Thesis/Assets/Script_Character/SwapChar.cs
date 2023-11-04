using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
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
    
    private CharacterStats[] _stats => CharacterStatusUI.Instance.Stats;
    private CharacterStats _stat;
    private ThirdPersonController TPC; 
    private Animator AM;


    public bool M_isAlive;
    public bool G_isAlive;
    
    
    private void Start()
    {
        M_isAlive = true;
        G_isAlive = true;
        mc_g.SetActive(true);
        mc_m.SetActive(false);

        TPC = GameObject.Find("Player").GetComponent<ThirdPersonController>();
        AM = GetComponent<Animator>();
    }

    private void Update()
    {
        _stat = CharacterStatusUI.Instance.CurrentActive(_stats);
        
        Debug.Log(_stat.CurrentHealth + _stat.name);
        

        if (_stat.CurrentHealth <= 0)
        {
            if (mc_g.activeInHierarchy)
            {
                mc_g.SetActive(false);
                G_isAlive = false;
                if (M_isAlive)
                {
                    mc_m.SetActive(true);
                }

                return;
            }
            mc_m.SetActive(false);
            M_isAlive = false;
            if (G_isAlive)
            {
                mc_g.SetActive(true);
            }
        }
        
        Die();

       
        
        if (!G_isAlive || !M_isAlive)
        {
            return;
        }
        SwapCharacter();

    }

    private void SwapCharacter()
    {
        if (Input.GetKeyDown(anyKey[0]) && _stat.CurrentHealth > 0)
        {
            mc_m.SetActive(false);
            mc_g.SetActive(true);
        }
        if (Input.GetKeyDown(anyKey[1]) && _stat.CurrentHealth > 0)
        {
            mc_g.SetActive(false);
            mc_m.SetActive(true);
        }
    }

    public void Die()
    {
        if (!M_isAlive && !G_isAlive)
        {
            Debug.Log("GameOver");
            TPC.enabled = false;
            AM.enabled = false;

            foreach (var stat in _stats)
            {
                stat.CurrentHealth = 0;
                
            }
        }
    }
}

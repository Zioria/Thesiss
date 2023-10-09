using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class DamgeMaker : MonoBehaviour
{
    [Header("Damage")] public int DM_Damage;

    public ThirdPersonController _controller;
    private CharacterStats[] _stats => CharacterStatusUI.Instance.Stats;
    private CharacterStats _stat;

    private void Awake()
    {
        _controller = GameObject.Find("Player").GetComponent<ThirdPersonController>();

    }
    
    void Update()
    {
        _stat = CharacterStatusUI.Instance.CurrentActive(_stats);
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !_controller.Dash_check)
        {
            GameObject.Find("CharacterStats");
            DealDamage();
        }
        
    }

    private void DealDamage()
    {
        _stat.CurrentHealth -= DM_Damage;

        
    }
}

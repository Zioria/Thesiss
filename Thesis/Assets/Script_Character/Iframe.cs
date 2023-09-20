using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class Iframe : MonoBehaviour
{
    public ThirdPersonController controller;
    CharacterController player;
    

    private void Awake()
    {
        controller = GetComponent<ThirdPersonController>();
        player = GetComponent<CharacterController>();
    }

    

    // Update is called once per frame
    void Update()
    {
        /*if (controller.Dash_check)
        {
            player.isTrigger = false;
            Debug.Log("you dodge");
        }
        else
        {
            player.isTrigger = true;
        }*/
    }
}

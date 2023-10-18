using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
  
   public void OnTriggerEnter(Collider other)
   {
      
      if (other.gameObject.tag == "Enermy")
      {
         Debug.Log("this enemy");
      }
   }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectLoopControl : MonoBehaviour
{
   private ParticleSystem partSys;

   public void Update()
   {
      Looping();
   }


   public void Looping()
   {
      partSys = GetComponent<ParticleSystem>();
      partSys.Stop();

      var particlaMainSetting = partSys.main;
      particlaMainSetting.loop ^= true;
      
      partSys.Play();
   }
}

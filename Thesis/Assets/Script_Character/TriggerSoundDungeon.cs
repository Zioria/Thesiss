using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSoundDungeon : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           SoundManager.instance.Stop(SoundManager.SoundName.BGMBoss);
           SoundManager.instance.Play(SoundManager.SoundName.BGMDangeon);
           SoundManager.instance.Stop(SoundManager.SoundName.BGMGameplay);
            
        }   
        
    }
}

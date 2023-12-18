using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSoundTown : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           SoundManager.instance.Stop(SoundManager.SoundName.BGMBoss);
           SoundManager.instance.Stop(SoundManager.SoundName.BGMDangeon);
           SoundManager.instance.Play(SoundManager.SoundName.BGMGameplay);
            
        }   
        
    }
}

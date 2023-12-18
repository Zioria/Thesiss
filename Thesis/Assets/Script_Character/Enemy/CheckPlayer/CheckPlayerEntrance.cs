using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerEntrance : MonoBehaviour
{
    [SerializeField] private BossHealthController bossHpController;

    private Animator _anim;
    public bool IsPlayerEnter;

    private void Awake()
    {
        _anim = GameObject.Find("BossHealthBarUI").GetComponent<Animator>();
    }

    private void Start()
    {
        IsPlayerEnter = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (!other.CompareTag("Player"))
        {
            
            return;
        }
        IsPlayerEnter = true;
        SoundManager.instance.Play(SoundManager.SoundName.BGMBoss);
        SoundManager.instance.Stop(SoundManager.SoundName.BGMDangeon);
        SoundManager.instance.Stop(SoundManager.SoundName.BGMGameplay);
            //if (bossHpController.IsOpenOnce)
        //{
        //    bossHpController.ShowHealthBar();
        //    return;
        //}
        _anim.SetTrigger("playerEnter");
        bossHpController.IsOpenOnce = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        SoundManager.instance.Stop(SoundManager.SoundName.BGMBoss);
        SoundManager.instance.Play(SoundManager.SoundName.BGMDangeon);
        SoundManager.instance.Stop(SoundManager.SoundName.BGMGameplay);
        IsPlayerEnter = false;
        _anim.SetTrigger("playerOut");
        //bossHpController.HideHealthBar_WithTime();
    }
}

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
        if (bossHpController.IsOpenOnce)
        {
            bossHpController.ShowHealthBar();
            return;
        }
        _anim.SetTrigger("playerEnter");
        bossHpController.IsOpenOnce = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        IsPlayerEnter = false;
        Invoke(nameof(bossHpController.HideHealthBar), 2f);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class SwapChar : MonoBehaviour
{
    [Header("Character")]
    public GameObject mc_g;
    public GameObject mc_m;

    [Header("CheckControl")] 
    public int addnumber_g = 1;
    public int addnumber_m = 2;
    
    public KeyCode[] anyKey;

    [Header("CharacterIcon")]
    [SerializeField] private Image imageActive;
    [SerializeField] private Image imageInActive;
    [SerializeField] private Sprite iconGirl;
    [SerializeField] private Sprite iconBoy;

    private CharacterStats[] _stats => CharacterStatusUI.Instance.Stats;
    private CharacterStats _stat;
    private ThirdPersonController TPC;
    private Animator _anim;
    private PlayerRespawn _playerRespawn;
    private bool _isSpawning;
    private int _GameOver;

    public bool M_isAlive;
    public bool G_isAlive;
    public int _GisDeadFirst;


    private void Start()
    {
        _GameOver = 0;
        M_isAlive = true;
        G_isAlive = true;
        mc_g.SetActive(true);
        mc_m.SetActive(false);
        imageActive.sprite = iconGirl;
        imageInActive.sprite = iconBoy;

        TPC = GetComponent<ThirdPersonController>();
        _anim = GetComponent<Animator>();
        _playerRespawn = GetComponent<PlayerRespawn>();
    }

    private void Update()
    {
        _stat = CharacterStatusUI.Instance.CurrentActive(_stats);
        
        //Debug.Log(_stat.CurrentHealth + _stat.name);
        

        if (_stat.CurrentHealth <= 0 && !_isSpawning)
        {
            _stat.CurrentHealth = 0;
            if (mc_g.activeInHierarchy)
            {
                mc_g.SetActive(false);
                G_isAlive = false;
                if (M_isAlive)
                {
                    mc_m.SetActive(true);
                    imageActive.sprite = iconBoy;
                    imageInActive.sprite = iconGirl;
                    _GisDeadFirst += 1;
                }

                return;
            }
            mc_m.SetActive(false);
            M_isAlive = false;
            if (G_isAlive)
            {
                mc_g.SetActive(true);
                imageActive.sprite = iconGirl;
                imageInActive.sprite = iconBoy;
            }
        }

        if (_GameOver > 0)
        {
            return;
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
            imageActive.sprite = iconGirl;
            imageInActive.sprite = iconBoy;
        }
        if (Input.GetKeyDown(anyKey[1]) && _stat.CurrentHealth > 0)
        {
            mc_g.SetActive(false);
            mc_m.SetActive(true);
            imageActive.sprite = iconBoy;
            imageInActive.sprite = iconGirl;
        }
    }

    public void Die()
    {
        if (!M_isAlive && !G_isAlive)
        {
            Debug.Log("GameOver");
            _GameOver += 1;
            TPC.IsDisable = true;
            _anim.enabled = false;
            foreach (var stat in _stats)
            {
                stat.CurrentHealth = 0;   
            }
            Invoke(nameof(SpawnPlayer), 2f);
        }
    }

    private void SpawnPlayer()
    {
        _isSpawning = true;
        foreach (var stat in _stats)
        {
            stat.CurrentHealth = stat.MaxHealth / 2;
        }
        gameObject.transform.position = _playerRespawn.PlayerSpawnpoint;
        Invoke(nameof(ResetController), .5f);
        if (_GisDeadFirst >= 1)
        {
            G_isAlive = true;
            mc_g.SetActive(true);
            imageActive.sprite = iconGirl;
            imageInActive.sprite = iconBoy;
            _GisDeadFirst = 0;
            M_isAlive = true;
            return;
        }
        M_isAlive = true;
        mc_m.SetActive(true);
        G_isAlive = true;
        imageActive.sprite = iconBoy;
        imageInActive.sprite = iconGirl;
    }

    private void ResetController()
    {
        TPC.IsDisable = false;
        _anim.enabled = true;
        _isSpawning = false;
        _GameOver = 0;
    }
}

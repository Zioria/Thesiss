using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class SwapChar : MonoBehaviour
{
    [Header("Character")]
    public GameObject mc_g;
    public GameObject mc_m;
    

    [Header("Gadjet")] public GameObject BagModel;

    [Header("CheckControl")] 
    public int addnumber_g = 1;
    public int addnumber_m = 2;
    
    public KeyCode[] anyKey;
    [SerializeField] private float timeBetweenChange;

    [Header("CharacterIcon")]
    [SerializeField] private Image imageGirl;
    [SerializeField] private Image imageBoy;
    [SerializeField] private Sprite iconGirl;
    [SerializeField] private Sprite iconBoy;
    [SerializeField] private TextMeshProUGUI girlTextNumber;
    [SerializeField] private TextMeshProUGUI boyTextNumber;

    [Header("Reference")]
    [SerializeField] private BossAI bossAI;
    [SerializeField] private Image imageCooldownOne, imageCooldownTwo;


    private CharacterStats[] _stats => CharacterStatusUI.Instance.Stats;
    private CharacterStats _stat;
    private ThirdPersonController TPC;
    private Animator _anim;
    private PlayerRespawn _playerRespawn;
    private bool _isSpawning;
    private int _GameOver;
    private bool _isChange;

    public bool M_isAlive;
    public bool G_isAlive;
    public int _GisDeadFirst;

    public bool IsChanging;


    private void Start()
    {
        _GameOver = 0;
        M_isAlive = true;
        G_isAlive = true;
        mc_g.SetActive(true);
        mc_m.SetActive(false);
        BagModel.SetActive(false);
        imageGirl.sprite = iconGirl;
        imageBoy.sprite = iconBoy;
        ModelGirlActive();
        _isChange = false;
        IsChanging = false;
        //itemheal.SetActive(false);

        TPC = GetComponent<ThirdPersonController>();
        _anim = GetComponent<Animator>();
        _playerRespawn = GetComponent<PlayerRespawn>();
    }

    private void Update()
    {
        _stat = CharacterStatusUI.Instance.CurrentActive(_stats);
        

        if (_stat.CurrentHealth <= 0 && !_isSpawning)
        {
            _stat.CurrentHealth = 0;
            if (mc_g.activeInHierarchy)
            {
                mc_g.SetActive(false);
                BagModel.SetActive(false);
                G_isAlive = false;
                if (M_isAlive)
                {
                    mc_m.SetActive(true);
                    BagModel.SetActive(true);

                    ModelBoyActive();

                    _GisDeadFirst += 1;
                }

                return;
            }
            mc_m.SetActive(false);
            BagModel.SetActive(false);
            M_isAlive = false;
            if (G_isAlive)
            {
                mc_g.SetActive(true);

                ModelGirlActive();
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
        if (_isChange)
        {
            imageCooldownOne.fillAmount -= 1 / (timeBetweenChange - .1f) * Time.deltaTime;
            if (imageCooldownOne.fillAmount <= 0)
            {
                imageCooldownOne.fillAmount = 0;
            }

            imageCooldownTwo.fillAmount -= 1 / (timeBetweenChange - .1f) * Time.deltaTime;
            if (imageCooldownTwo.fillAmount <= 0)
            {
                imageCooldownTwo.fillAmount = 0;
            }
        }
        SwapCharacter();
        
        //if(mc_m.activeInHierarchy)
      //  {
          //GameObject[] HealHolderObject = new GameObject[itemHeal];
          //GameObject.FindGameObjectWithTag ("Heal");
          //if(other.CompareTag("Player"))
         // {
            //itemheal = GameObject.FindWithTag ("Heal");
           // itemheal.SetActive(true);
         // }
          
          
       // }

       // if(mc_g.activeInHierarchy)
       // {
          //GameObject[] itemHeal = GameObject.FindGameObjectWithTag ("Heal");
          //foreach (GameObject Heal in itemheal)
          //{
            //itemheal = GameObject.FindWithTag("Heal");
          //  itemheal.SetActive(false);
          //GameObject[] itemheal = new GameObject itemHeal;
         // itemheal = GameObject.FindWithTag ("Heal");
         // itemheal.SetActive(false);
          
       // }
            
       // }
        

    }

    private void ModelGirlActive()
    {
        imageGirl.color = Color.grey;
        imageBoy.color = Color.white;
        girlTextNumber.color = Color.grey;
        boyTextNumber.color = Color.white;
    }

    private void ModelBoyActive()
    {
        imageGirl.color = Color.white;
        imageBoy.color = Color.grey;
        girlTextNumber.color = Color.white;
        boyTextNumber.color = Color.grey;
    }
    

    private void SwapCharacter()
    {
        if (_isChange)
        {
            return;
        }

        if (Input.GetKeyDown(anyKey[0]) && _stat.CurrentHealth > 0 && !mc_g.activeInHierarchy)
        {
            _anim.Play("Idle");
            mc_m.SetActive(false);
            BagModel.SetActive(false);
            mc_g.SetActive(true);

            ModelGirlActive();

            imageCooldownOne.fillAmount = 1;
            imageCooldownTwo.fillAmount = 1;
            _isChange = !_isChange;
            IsChanging = !IsChanging;
            Invoke(nameof(ResetChange), .5f);
            Invoke(nameof(ResetTimeChange), timeBetweenChange);
            //itemheal = GameObject.FindWithTag ("Heal");
            //itemheal.SetActive(false);
        }
        if (Input.GetKeyDown(anyKey[1]) && _stat.CurrentHealth > 0 && !mc_m.activeInHierarchy)
        {
            _anim.Play("Idle");
            mc_g.SetActive(false);
            mc_m.SetActive(true);
            BagModel.SetActive(true);

            ModelBoyActive();

            imageCooldownOne.fillAmount = 1;
            imageCooldownTwo.fillAmount = 1;
            _isChange = !_isChange;
            IsChanging = !IsChanging;
            Invoke(nameof(ResetChange), .5f);
            Invoke(nameof(ResetTimeChange), timeBetweenChange);
            //itemheal.SetActive(true);
        }
    }

    private void ResetChange()
    {
        IsChanging = !IsChanging;
    }

    private void ResetTimeChange()
    {
        _isChange = !_isChange;
    }

    public void Die()
    {
        if (!M_isAlive && !G_isAlive)
        {
            Debug.Log("GameOver");

            imageGirl.color = Color.grey;
            imageBoy.color = Color.grey;
            girlTextNumber.color = Color.grey;
            boyTextNumber.color = Color.grey;

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

            imageGirl.color = Color.grey;
            imageBoy.color = Color.white;
            girlTextNumber.color = Color.grey;
            boyTextNumber.color = Color.white;

            _GisDeadFirst = 0;
            M_isAlive = true;
            return;
        }
        M_isAlive = true;
        mc_m.SetActive(true);
        BagModel.SetActive(true);

        imageGirl.color = Color.white;
        imageBoy.color = Color.grey;
        girlTextNumber.color = Color.white;
        boyTextNumber.color = Color.grey;

        G_isAlive = true;
        //imageActive.sprite = iconBoy;
        //imageInActive.sprite = iconGirl;
        bossAI.SetSpawn();
    }

    public void PreventFall()
    {
        TPC.IsDisable = true;
        _anim.enabled = false;
        gameObject.transform.position = _playerRespawn.PlayerSpawnpoint;
        Invoke(nameof(ResetController), .5f);
    }

    private void ResetController()
    {
        TPC.IsDisable = false;
        _anim.enabled = true;
        _isSpawning = false;
        _GameOver = 0;
    }
}

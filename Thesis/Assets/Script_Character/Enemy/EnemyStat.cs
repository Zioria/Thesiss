using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStat : MonoBehaviour
{
    [SerializeField] private StatsEnemyScriptable stat;
    [SerializeField] private float attackRange;
    [SerializeField] private float chaseRange;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private float defultSpeed;

    private float _healthPoint;
    private GameObject _enemy;
    private Animator _anim;
    private GameObject _player;
    private static readonly int _deathAnim = Animator.StringToHash("isDeath");
    private static readonly int _getHitAnim = Animator.StringToHash("isGetHit");
    private EnemyHealthBar _healthBar;
    private bool _playerInrange;

    public bool isEnemyDie;
    public bool isPatrol;
    public Vector3 Setposition;
    public StatsEnemyScriptable Stat => stat;
    public float AttackRange => attackRange;
    public float ChaseRange => chaseRange;
    public float SpeedAgent;
    public float DefultSpeed => defultSpeed;

    private void Awake()
    {
        Setposition = transform.position;
        _enemy = this.gameObject;
        _anim = GetComponent<Animator>();
        _player = GameObject.FindWithTag("Player");
        _healthBar = GetComponentInChildren<EnemyHealthBar>();
    }

    private void Start()
    {
        Initialize();
        _healthBar.UpdateHealthBar(_healthPoint, stat.MaxHealth);
    }

    private void Update()
    {
        HealthBarController();
    }

    private void Initialize()
    {
        _healthPoint = stat.MaxHealth;
    }

    private void HealthBarController()
    {
        _playerInrange = Physics.CheckSphere(transform.position, ChaseRange, playerMask);
        if (!_playerInrange)
        {
            _healthBar.gameObject.SetActive(false);
            return;
        }
        _healthBar.gameObject.SetActive(true);
    }

    public void TakeDamage(float damage)
    {
        _healthPoint -= damage;
        _healthBar.UpdateHealthBar(_healthPoint, stat.MaxHealth);

        if (_healthPoint <= 0)
        {
            _healthBar.gameObject.SetActive(false);
            isEnemyDie = true;
            _enemy.gameObject.tag = "Die";
            _anim.SetTrigger(_deathAnim);
            Die();
            Player.Instance.GoBattle();
            Disappear();
            return;
        }
    }

    
    private void Die()
    {
        //_enemy.SetActive(false);
        _anim.GetComponent<Collider>().enabled = false;
        _anim.GetComponent<NavMeshAgent>().SetDestination(gameObject.transform.position);
    }

   private void Disappear()
   {
       Destroy(this.gameObject ,3);
   }

    public void StartDealDamage()
    {
        GetComponentInChildren<WeaponDamageMarker>().StartDealDamage();
    }

    public void EndDealDamage()
    {
        GetComponentInChildren<WeaponDamageMarker>().EndDealDamage();
    }

    public void UpdateSpeedAgent()
    {
        SpeedAgent = defultSpeed;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}

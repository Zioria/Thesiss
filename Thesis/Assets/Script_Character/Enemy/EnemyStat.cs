using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStat : MonoBehaviour, IDamagable
{
    [SerializeField] private StatsEnemyScriptable stat;
    [SerializeField] private float attackRange;
    [SerializeField] private float chaseRange;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private float defultSpeed;
    [SerializeField] private GameObject floatingTextPrefab;
    
    private float _healthPoint;
    private GameObject _enemy;
    private Animator _anim;
    private GameObject _player;
    private static readonly int _deathAnim = Animator.StringToHash("isDeath");
    private static readonly int _getHitAnim = Animator.StringToHash("isGetHit");
    private EnemyHealthBar _healthBar;
    private bool _playerInrange;

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
    }

    private void Initialize()
    {
        _healthPoint = stat.MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        ShowDamage(damage.ToString());
        _healthPoint -= damage;
        _healthBar.UpdateHealthBar(_healthPoint, stat.MaxHealth);
        Debug.Log(_healthPoint);
        if (_healthPoint <= 0)
        {
            Die();
            _healthBar.gameObject.SetActive(false);
            _enemy.gameObject.tag = "Die";
            _anim.SetTrigger(_deathAnim);
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
        Destroy(this.gameObject, 3);
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

    public void Damage(float damageAmount)
    {
        TakeDamage(damageAmount);
    }

    void ShowDamage(string text)
    {
        if (floatingTextPrefab)
        {
            GameObject prefab = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;
        }
    }
}

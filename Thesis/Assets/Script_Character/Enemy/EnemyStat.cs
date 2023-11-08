using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
public class EnemyStat : MonoBehaviour
{
    [SerializeField] private StatsEnemyScriptable stat;
    [SerializeField] private float attackRange;
    [SerializeField] private float chaseRange;

    private float _healthPoint;

    private GameObject _enemy;
    private Animator _anim;
    private GameObject _player;
    private static readonly int _deathAnim = Animator.StringToHash("isDeath");
    private static readonly int _getHitAnim = Animator.StringToHash("isGetHit");

    public bool isEnemyDie;
    public StatsEnemyScriptable Stat => stat;
    public float AttackRange => attackRange;
    public float ChaseRange => chaseRange;

    private void Awake()
    {
        _enemy = this.gameObject;
        _anim = GetComponent<Animator>();
        _player = GameObject.FindWithTag("Player");
    }

    private void Initialize()
    {
        _healthPoint = stat.MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        _healthPoint -= damage;
        Debug.Log(_enemy.name + damage);

        if (_healthPoint <= 0)
        {
            isEnemyDie = true;
            _enemy.gameObject.tag = "Die";
            _anim.SetTrigger(_deathAnim);
            Die();
            Player.Instance.GoBattle();
            Disappear();
            return;
        }

        //_anim.SetTrigger(_getHitAnim);
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStat : MonoBehaviour
{
    [SerializeField] private float healthPoint;
    [SerializeField] private float minDestroy;
    [SerializeField] private float maxDestroy;


    public float AttackRange;
    public float ChaseRange;

    private GameObject _enemy;
    private Animator _anim;
    private GameObject _player;
    private static readonly int _deathAnim = Animator.StringToHash("isDeath");
    private static readonly int _getHitAnim = Animator.StringToHash("isGetHit");

    public bool isEnemyDie;
    // public static Player Instance;
    // public GameObject questB;

    private void Awake()
    {
        _enemy = this.gameObject;
        _anim = GetComponent<Animator>();
        _player = GameObject.FindWithTag("Player");
    }
    

    public void TakeDamage(float damage)
    {
        healthPoint -= damage;

        if (healthPoint <= 0)
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
        Gizmos.DrawWireSphere(transform.position, AttackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, ChaseRange);
    }
}

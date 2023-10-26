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
            _enemy.gameObject.tag = "Die";
            _anim.SetTrigger(_deathAnim);
            Invoke("Die", 3);
            Player.Instance.GoBattle();
            return;
        }

        _anim.SetTrigger(_getHitAnim);
    }

    
    private void Die()
    {
        Destroy(this.gameObject);
        isEnemyDie = true;
        //_enemy.SetActive(false);
        _anim.GetComponent<Collider>().enabled = false;
        _anim.GetComponent<NavMeshAgent>().SetDestination(gameObject.transform.position);
        
        
    }

   
}

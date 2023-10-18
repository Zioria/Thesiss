using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;


public class MaleeAttack : MonoBehaviour
{
    public static MaleeAttack Instance;
    public Animator animator;
    private PlayerInput _input;
    private ThirdPersonController _controller;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public bool Attacking;

    [SerializeField] private float attackValue;
    [SerializeField] private float timeBetweenAttack;

    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        Instance = this;

        _controller = GetComponent<ThirdPersonController>();
    }

    public void OnAttack(InputValue value)
    {
        if (_controller.Grounded && !Attacking)
        {
            attack();
        }
    }

    void attack()
    {
        animator.SetTrigger("Attack");
        Collider[] hitEnemy = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider enemy in hitEnemy)
        {
            if (enemy.TryGetComponent(out EnemyStat enemyStat))
            {
                enemyStat.TakeDamage(attackValue);
            }
        }
        Attacking = !Attacking;
        Invoke(nameof(ResetAttack), timeBetweenAttack);
    }

    private void ResetAttack()
    {
        Attacking = !Attacking;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

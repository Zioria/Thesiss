using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;


public class MaleeAttack : MonoBehaviour
{
    public Animator animator;
    private PlayerInput _input;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public void OnAttack(InputValue value)
    {
        attack();
        Debug.Log("Attack!");
    }

    void attack()
    {
        animator.SetTrigger("Attack");
        Collider[] hitEnemy = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider enemy in hitEnemy)
        {
            Destroy(enemy.gameObject);
            Debug.Log("We hit" + enemy.name);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

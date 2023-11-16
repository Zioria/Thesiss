using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;
using Unity.Mathematics;
using UnityEngine.UIElements;


public class MCGattack : MonoBehaviour
{
    public Transform Player;
    public static MCGattack Instance;
    public Animator animator;
    private PlayerInput _input;
    private ThirdPersonController _controller;
    public Transform nearestEnemy;
    private CharacterStats[] _stats => CharacterStatusUI.Instance.Stats;
    private CharacterStats _stat;
    

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public float OverlapRadius = 10.0f;
    public float minimumDistance;
    public LayerMask enemyLayers;
    public bool Attacking;

    [SerializeField] private float attackValue;
    [SerializeField] private float timeBetweenAttack;

    [Header("Find Enemy")] 
    public GameObject mc_G;
    public float rotationSpeed;
    private EnemyStat _enemystat;
    

    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }

        Instance = this;
        
        _enemystat = GetComponent<EnemyStat>();
        _controller = GetComponent<ThirdPersonController>();
    }
    

    public void OnAttack(InputValue value)
    {
        if (_controller.Grounded && !Attacking && mc_G.activeInHierarchy)
        {
            animator.SetTrigger("Idle");
            attack();
        }
    }

    void Update()
    {
        _stat = CharacterStatusUI.Instance.CurrentActive(_stats);
        attackValue = _stat.Damage;
        
       FindEnemy();

        if (Attacking)
        {
            if (nearestEnemy != null )
            {
                Vector3 directionToTarget = nearestEnemy.transform.position - transform.position;
                directionToTarget.y = 0; // If you don't want to rotate in the y-axis

                if (directionToTarget != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
                    transform.rotation =
                        Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
                }
            }
        }


    }

    void attack()
    {
        animator.SetTrigger("Attack");
        Collider[] hitEnemy = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider enemy in hitEnemy)
        {
            if (nearestEnemy)
            {
                if (enemy.TryGetComponent(out EnemyStat enemyStat))
                {
                    enemyStat.TakeDamage(attackValue);
                }
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

    void FindEnemy()
    { 
        Collider[] hitColliders = Physics.OverlapSphere(Player.position, OverlapRadius, enemyLayers);
        float minimumDistance = Mathf.Infinity;
        foreach(Collider collider in hitColliders)
        {
            float distance = Vector3.Distance(Player.position, collider.transform.position);
            if (distance < minimumDistance)
            {
                minimumDistance = distance;
                nearestEnemy = collider.transform;
            }
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Player.position, OverlapRadius);
    }
}

    

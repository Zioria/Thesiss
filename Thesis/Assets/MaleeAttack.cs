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

    [Header("Find Enemy")] public GameObject[] Allenemy;
    public GameObject NearestENM;
    public float distance;
    public float nearstDistance;
    public GameObject Player;
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
        if (_controller.Grounded && !Attacking)
        {

            attack();
        }
    }

    void Update()
    {
       FindEnemy();

        if (Attacking)
        {
            if (NearestENM != null && NearestENM.activeInHierarchy)
            {
                Vector3 directionToTarget = NearestENM.transform.position - transform.position;
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

    void FindEnemy()
    {
        Allenemy = GameObject.FindGameObjectsWithTag("Enermy");

        for (int i = 0; i < Allenemy.Length; i++)
        {
            distance = Vector3.Distance(this.transform.position, Allenemy[i].transform.position);

            if (distance <= nearstDistance)
            {
                NearestENM = Allenemy[i]; 
            }
            else
            {
                NearestENM = null;
            }
            


        }
    }
}

    

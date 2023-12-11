using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;
using Unity.Mathematics;
using Unity.VisualScripting;
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

    public float speedStep;
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
    private Transform target;
    private EnemyStat _enemystat;


    [Header("GrapClose")] 
    public float Distancedelta;
    [SerializeField]private float minRange;
    [SerializeField]private float maxRange;
    public float Duration;
    

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
            
            attack();
        }
    }

    void Update()
    {
        _stat = CharacterStatusUI.Instance.CurrentActive(_stats);
        attackValue = _stat.Damage;

        FindEnemy();
        
    }

    void attack()
    {
        
        
        animator.SetTrigger("Attack");
        if (nearestEnemy == null )
        {
           
                return;
            
        }
         Vector3 directionToTarget = nearestEnemy.transform.position - transform.position;
            directionToTarget.y = 0; // If you don't want to rotate in the y-axis

            if (directionToTarget != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
                transform.rotation =
                    Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
                    
            }
        GrapClose(target);
        //Attacking = !Attacking;
        //Invoke(nameof(ResetAttack), timeBetweenAttack);
    }

    
    
    private void ResetAttack()
    {
        Attacking = !Attacking;
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

    void GrapClose(Transform target)
    {
        if (Vector3.Distance(transform.position, nearestEnemy.position) > minRange &&
            Vector3.Distance(transform.position, nearestEnemy.position) < maxRange)
        {
            transform.DOMove(TragetOffset(), Duration);
        }
    }

    public Vector3 TragetOffset()
    {
        Vector3 position;
        position = nearestEnemy.position;
        return Vector3.MoveTowards(new Vector3(position.x, 1, position.z), transform.position, Distancedelta);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Player.position, OverlapRadius);
    }
}

    

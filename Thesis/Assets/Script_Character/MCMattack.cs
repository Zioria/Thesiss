using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;
using Unity.Mathematics;
using UnityEngine.UIElements;


public class MCMattack : MonoBehaviour
{
    public Transform Player;
    public static MCMattack Instance;
    public Animator animator;
    private PlayerInput _input;
    private ThirdPersonController _controller;
    public Transform nearestEnemy;
    private CharacterStats[] _stats => CharacterStatusUI.Instance.Stats;
    private CharacterStats _stat;

    //BBagModle
    public GameObject BagModel;

    //public Transform attackPoint;
    public Transform BulletSpawnPoint;
    public GameObject Bulletprefab;
    public float BulletSpeeds;
    public float angleChaningSpeed;
    public float OverlapRadius = 10.0f;
    public float minimumDistance;
    public LayerMask enemyLayers;
    public bool Attacking;
    public float InvokeBbullet;

    [SerializeField] private float timeBetweenAttack;

    [Header("Find Enemy")] public float attackValue;
    public GameObject mc_M;
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
        if (_controller.Grounded && !Attacking && mc_M.activeInHierarchy)
        {
            Animattack();
            Invoke("Onattack", InvokeBbullet);
        }
    }

    void Update()
    {
        
        _stat = CharacterStatusUI.Instance.CurrentActive(_stats);
        attackValue = _stat.Damage;

        FindEnemy();

        if (Attacking)
        {

            if (nearestEnemy != null)
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

    void Animattack()
    {

        
        Debug.Log("Attackk!!!");
        animator.SetTrigger("RangeAttack");
        Attacking = !Attacking;
        
    }

    private void ResetAttack()
    {
        Attacking = !Attacking;
    }

    void Onattack()
    {
        //RangeAttack
        var bullet = Instantiate(Bulletprefab, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
        bullet.transform.Rotate(0,90,0);
        bullet.GetComponent<Rigidbody>().velocity = BulletSpawnPoint.forward * BulletSpeeds;
        
        Invoke(nameof(ResetAttack), timeBetweenAttack);

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

    public void HideBag()
    {
        BagModel.SetActive(false);
    }

    public void ShowBag()
    {
        BagModel.SetActive(true);
    }

    
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(Player.position, OverlapRadius);
    }
}
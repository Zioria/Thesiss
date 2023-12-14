using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIController : MonoBehaviour
{
    #region Variable
    [SerializeField] private Transform playerPos;
    [SerializeField] private LayerMask whatIsGround, whatIsPlayer;

    [Header("Setting Patrolling")]
    [SerializeField] private Vector3 walkPoint;
    [SerializeField] private float walkPointRange;
    [SerializeField] private float timeBetweenPatrolMin;
    [SerializeField] private float timeBetweenPatrolMax;
    [SerializeField] private float speedWalk;
    [SerializeField] private float chasingSpeed;

    [Header("Setting Attacking")]
    [SerializeField] private float timeBetweenAttack;

    [Header("Setting For State")]
    [SerializeField] private float sightRange;
    [SerializeField] private float attackRange;
    [SerializeField] private bool playerInSightRange, playerInAttackRange;

    private NavMeshAgent _agent;
    private Animator _anim;
    private bool _walkPointSet;
    private bool _alreadyAttacked;
    private int _currentWaypoint;
    private float _timeChangeDestination;
    public bool _isDestination;

    #endregion

    #region UnityMethod
    private void Awake()
    {
        playerPos = GameObject.Find("Player").transform;
        _agent = GetComponent<NavMeshAgent>();
        _currentWaypoint = 0;
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckRange();
        
    }

    #endregion

    #region CustomMethod
    private void Patrolling()
    {
        _agent.isStopped = false;
        _agent.speed = speedWalk;
        _anim.SetFloat("Speed", 0.5f);
        if (!_walkPointSet)
        {
            SearchWalkPoint();
            return;
        }
        if (_agent.remainingDistance > 1)
        {
            return;
        }
        if (_isDestination)
        {
            _anim.SetFloat("Speed", 0);
            return;
        }

        _agent.SetDestination(WaypointManager.Instance.Children[_currentWaypoint].position);
        _walkPointSet = false;
        _timeChangeDestination = UnityEngine.Random.Range(timeBetweenPatrolMin, timeBetweenPatrolMax);
        _isDestination = !_isDestination;
        Invoke(nameof(ResetDestination), _timeChangeDestination);
    }

    private void SearchWalkPoint()
    {
        _currentWaypoint++;
        if (_currentWaypoint >= WaypointManager.Instance.Children.Count)
        {
            _currentWaypoint = 0;
        }
        _walkPointSet = true;
                
    }

    private void ChasingPlayer()
    {
        _agent.speed = chasingSpeed;
        _anim.SetFloat("Speed", 1);
        _agent.SetDestination(playerPos.position);
    }

    private void AttackingPlayer()
    {
        //Make Enemy not move
        _agent.SetDestination(transform.position);

        //Looking at Player
        transform.LookAt(playerPos);

        if (!_alreadyAttacked)
        {
            ///Attack code
            _anim.SetTrigger("Attack");
            ///End
            
            _alreadyAttacked = !_alreadyAttacked;
            Invoke(nameof(ResetAttack), timeBetweenAttack);
        }
    }

    private void ResetAttack()
    {
        _alreadyAttacked = !_alreadyAttacked;
    }
    private void ResetDestination()
    {
        _isDestination = !_isDestination;
    }

    private void CheckRange()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange && !_alreadyAttacked) Patrolling();
        if (playerInSightRange && !playerInAttackRange && !_alreadyAttacked) ChasingPlayer();
        if (playerInSightRange && playerInAttackRange) AttackingPlayer();
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
    #endregion
}

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

    [Header("Setting Attacking")]
    [SerializeField] private float timeBetweenAttack;

    [Header("Setting For State")]
    [SerializeField] private float sightRange, attackRange;
    [SerializeField] private bool playerInSightRange, playerInAttackRange;

    private NavMeshAgent _agent;
    private bool _walkPointSet;
    private bool _alreadyAttacked;
    private int _currentWaypoint;
    #endregion

    #region UnityMethod
    private void Awake()
    {
        playerPos = GameObject.Find("Player").transform;
        _agent = GetComponent<NavMeshAgent>();
        _currentWaypoint = 0;
    }

    private void Update()
    {
        CheckRange();
    }

    #endregion

    #region CustomMethod
    private void Patrolling()
    {
        if (!_walkPointSet)
        {
            SearchWalkPoint();
            return;
        }

        _agent.SetDestination(GameEnvironment.Instance.Waypoints[_currentWaypoint].transform.position);
        if (_agent.remainingDistance < 1)
        {
            _walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        _currentWaypoint++;
        if (_currentWaypoint >= GameEnvironment.Instance.Waypoints.Count)
        {
            _currentWaypoint = 0;
        }
        _walkPointSet = true;
    }

    private void ChasingPlayer()
    {
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
            
            ///End

            _alreadyAttacked = !_alreadyAttacked;
            Invoke(nameof(ResetAttack), timeBetweenAttack);
        }
    }

    private void ResetAttack()
    {
        _alreadyAttacked = !_alreadyAttacked;
    }

    private void CheckRange()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patrolling();
        if (playerInSightRange && !playerInAttackRange) ChasingPlayer();
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

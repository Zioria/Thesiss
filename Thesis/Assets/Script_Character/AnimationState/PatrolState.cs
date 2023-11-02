using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : StateMachineBehaviour
{
    //[SerializeField] private float _chaseRange;
    [SerializeField] private float agentSpeed;
    private EnemyStat _enemyStat;
    private NavMeshAgent _agent;
    private int _currentIndex;
    private int _tempIndex;
    private Transform _playerPos;
    private static readonly int _patrolAnim = Animator.StringToHash("isPatrol");
    private static readonly int _chaseAnim = Animator.StringToHash("isChase");

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _enemyStat = animator.GetComponent<EnemyStat>();
        _agent = animator.GetComponent<NavMeshAgent>();
        _agent.speed = agentSpeed;
        _playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        _tempIndex = _currentIndex = Random.Range(0, WaypointManager.Instance.Children.Count);
        _agent.SetDestination(WaypointManager.Instance.Children[_currentIndex].position);
        animator.SetBool(_patrolAnim, true);
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector3.Distance(_playerPos.position, animator.transform.position);
        if (distance < _enemyStat.ChaseRange)
        {
            animator.SetBool(_chaseAnim, true);
            return;
        }

        if (_agent.remainingDistance >= 1)
        {
            return;
        }

        if (_tempIndex == _currentIndex)
        {
            _currentIndex = Random.Range(0, WaypointManager.Instance.Children.Count);
        }

        _agent.SetDestination(WaypointManager.Instance.Children[_currentIndex].position);
        _tempIndex = _currentIndex;
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.SetDestination(_agent.transform.position);
        animator.SetBool(_patrolAnim, false);
    }

    ////OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    ////OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}

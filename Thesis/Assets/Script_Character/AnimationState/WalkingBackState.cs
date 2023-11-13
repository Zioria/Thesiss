using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkingBackState : StateMachineBehaviour
{
    [SerializeField] private float speed;
    private NavMeshAgent _agent;
    private EnemyStat _enemyStat;
    private Transform _playerPos;
    private static readonly int _chaseAnim = Animator.StringToHash("isChase");
    private static readonly int _walkBackAnim = Animator.StringToHash("isWalkBack");
    private static readonly int _idleAnim = Animator.StringToHash("isIdle");

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        _agent = animator.GetComponent<NavMeshAgent>();
        _agent.speed = speed;
        _enemyStat = animator.GetComponent<EnemyStat>();
        _agent.SetDestination(_enemyStat.Setposition);
        animator.SetBool(_walkBackAnim, true);
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
        if (_agent.remainingDistance <= 0)
        {
            animator.SetBool(_idleAnim, true);
            return;
        }
        _agent.SetDestination(_enemyStat.Setposition);

    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(_walkBackAnim, false);
    }

    //OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}

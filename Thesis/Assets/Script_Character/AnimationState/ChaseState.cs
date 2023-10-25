using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : StateMachineBehaviour
{
    [SerializeField] private float agentSpeed;
    [SerializeField] private float attackRange;
    [SerializeField] private float chaseRange;
    private NavMeshAgent _agent;
    private Transform _playerPos;
    private static readonly int _chaseAnim = Animator.StringToHash("isChase");
    private static readonly int _attackAnim = Animator.StringToHash("isAttack");
    private static readonly int _idleAnim = Animator.StringToHash("isIdle");
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent = animator.GetComponent<NavMeshAgent>();
        _playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        _agent.speed = agentSpeed;
        animator.SetBool(_chaseAnim, true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector3.Distance(_playerPos.position, animator.transform.position);
        if (distance > chaseRange)
        {
            animator.SetBool(_idleAnim, true);
            return;
        }

        if (distance <=attackRange)
        {
            animator.SetBool(_attackAnim, true);
            return;
        }
        _agent.SetDestination(_playerPos.position);

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.SetDestination(animator.transform.position);
        animator.SetBool(_chaseAnim, false);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
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

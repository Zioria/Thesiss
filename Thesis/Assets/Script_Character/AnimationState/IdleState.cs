using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    
    //[SerializeField] private float attackRange;
    private Transform _playerPos;
    private EnemyStat _enemyStat;
    private static readonly int _patrolAnim = Animator.StringToHash("isPatrol");
    private static readonly int _idleAnim = Animator.StringToHash("isIdle");
    private static readonly int _attackAnim = Animator.StringToHash("isAttack");
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _enemyStat = animator.GetComponent<EnemyStat>();
        _playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        animator.SetBool(_idleAnim, true);
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        float distance = Vector3.Distance(_playerPos.position, animator.transform.position);
        if (distance <= _enemyStat.AttackRange)
        {
            animator.SetBool(_attackAnim, true);
            return;
        }
        if (Random.Range(0, 100) < 10)
        {
            animator.SetBool(_patrolAnim, true);
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(_idleAnim, false);
    }

    //OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    //OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}

using UnityEngine;
using UnityEngine.AI;


public class AttackState : StateMachineBehaviour
{
    //[SerializeField] private float attackRange;
    [SerializeField] private float timeBetweenAttack;

    private EnemyStat _enemyStat;
    private NavMeshAgent _agent;
    private Transform _playerPos;
    private float _timer;
    private static readonly int _attackAnim = Animator.StringToHash("isAttack");
    private static readonly int _idleAnim = Animator.StringToHash("isIdle");
    private static readonly int _chaseAnim = Animator.StringToHash("isChase");

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _enemyStat = animator.GetComponent<EnemyStat>();
        _agent = animator.GetComponent<NavMeshAgent>();
        _playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        _timer = 0;
        _agent.SetDestination(_agent.transform.position);
        animator.SetBool(_attackAnim, true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.SetDestination(animator.transform.position);
        animator.transform.LookAt(_playerPos);
        var rot = animator.transform.eulerAngles;
        rot.x = 0;
        animator.transform.eulerAngles = rot;
        float distance = Vector3.Distance(_playerPos.position, animator.transform.position);
        if (distance > _enemyStat.AttackRange)
        {
            _timer += Time.deltaTime;
        }

        if (_timer < timeBetweenAttack)
        {
            return;
        }
        if (_enemyStat.isPatrol)
        { 
            animator.SetBool(_idleAnim, true);
            return;
        }
        animator.SetBool(_chaseAnim, true);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(_attackAnim, false);
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

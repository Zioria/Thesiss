using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

[RequireComponent(typeof(NavMeshAgent))]
public class BossAI : MonoBehaviour
{
    [Header("Agent Setting")]
    [SerializeField] private CheckPlayerEntrance checkPlayer;
    [SerializeField] private float speedAgent;
    [SerializeField] private float timeBetweenAttack;

    [Header("For Jump Attack")]
    [SerializeField] private float jumpHeight;
    [SerializeField] private float jumpDuration;
    [SerializeField] private Transform groundCheckPosition;
    [SerializeField] private LayerMask whatisGround;
    [SerializeField] private Vector3 boxSize;

    [Header("Skill Setting")]
    [SerializeField] private float cooldownSkill;
    private bool _isActivating;

    private Transform _player;
    private NavMeshAgent _agent;
    private Animator _anim;
    private bool _isAttacking;
    private bool _isGrounded;
    private Vector3 _distanceFromPlayer;
    private static readonly int _AttackAnim = Animator.StringToHash("Attack");
    private static readonly int _JAttackAnim = Animator.StringToHash("JumpAttack");

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _anim = GetComponent<Animator>();
        _agent.speed = speedAgent;
        _isAttacking = false;
    }

    private void LateUpdate()
    {
        //if (!checkPlayer.IsPlayerEnter)
        //{
        //    return;
        //}
        if (_isAttacking)
        {
            return;
        }
        _isGrounded = Physics.CheckBox(groundCheckPosition.position, boxSize, Quaternion.identity, whatisGround);
        if (Input.GetKeyDown(KeyCode.K))
        {
            JumpAttack();
        }
        _agent.SetDestination(_player.position);
        _anim.ResetTrigger(_AttackAnim);

        Attack();
    }

    private void Attack()
    {
        float distance = Vector3.Distance(transform.position, _player.position);
        if (distance <= 1)
        {
            _agent.SetDestination(transform.position);
            _anim.SetTrigger(_AttackAnim);
            _isAttacking = true;
            Invoke(nameof(ResetAttack), timeBetweenAttack);
        }
    }

    private void ResetAttack()
    {
        _isAttacking = !_isAttacking;
    }

    public void JumpAttack()
    {

        if (_isGrounded)
        {
            transform.DOJump(_player.position, jumpHeight, 1, jumpDuration);

            transform.LookAt(_player.position);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(groundCheckPosition.position, boxSize);
    }
}

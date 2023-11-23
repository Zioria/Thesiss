using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class BossAI : MonoBehaviour
{
    [SerializeField] private CheckPlayerEntrance checkPlayer;
    [SerializeField] private float speedAgent;
    [SerializeField] private float timeBetweenAttack;

    [Header("Jump Attack")]
    [SerializeField] private float jumpPower;
    [SerializeField] private float jDuration;

    private Transform _player;
    private NavMeshAgent _agent;
    private Animator _anim;
    public bool _isAttacking;
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

    private void Update()
    {
        if (!checkPlayer.IsPlayerEnter)
        {
            return;
        }
        if (_isAttacking)
        {
            return;
        }

        _agent.SetDestination(_player.position);
        _anim.SetBool("IsPlayerEnter", true);
        _anim.ResetTrigger(_AttackAnim);

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
        Vector3 lPlayerPosition = _player.position;
        transform.DOJump(lPlayerPosition, jumpPower, 1, jDuration);
    }
}

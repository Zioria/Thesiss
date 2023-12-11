using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

[RequireComponent(typeof(NavMeshAgent))]
public class BossAI : MonoBehaviour, IDamagable
{
    [SerializeField] private GameObject floatingTextPrefab;
    
    [SerializeField] private StatsEnemyScriptable stat;
    [Header("Agent Setting")]
    [SerializeField] private CheckPlayerEntrance checkPlayer;
    [SerializeField] private float speedAgent;
    [SerializeField] private float timeBetweenAttack;
    [SerializeField] private float rangeAttack;

    [Header("For Jump Attack")]
    [SerializeField] private float jumpHeight;
    [SerializeField] private float jumpDuration;
    [SerializeField] private Transform groundCheckPosition;
    [SerializeField] private LayerMask whatisGround;
    [SerializeField] private Vector3 boxSize;

    [Header("Skill Setting")]
    [SerializeField] private float cooldownSkill;
    [SerializeField] private float minDistanceSkill;
    [SerializeField] private float maxDistanceSkill;

    private Vector3 spawnPoint;
    private Transform _player;
    private NavMeshAgent _agent;
    private Animator _anim;
    private bool _isAttacking;
    private bool _isGrounded;
    private float _distanceFromPlayer;
    private float _healthPoint;
    [SerializeField] private float _coolDown;
    public StateSkill _state;
    private EnemyHealthBar _healthBar;
    private static readonly int _AttackAnim = Animator.StringToHash("Attack");
    private static readonly int _JAttackAnim = Animator.StringToHash("Jump");
    private static readonly int _DeadAnim = Animator.StringToHash("Death");
    private static readonly int _ChaseAnim = Animator.StringToHash("isChase");

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _anim = GetComponent<Animator>();
        _healthBar = GetComponentInChildren<EnemyHealthBar>();
        _agent.speed = speedAgent;
        spawnPoint = transform.position;
    }

    private void Start()
    {
        _healthPoint = stat.MaxHealth;
        _coolDown = cooldownSkill;
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

        switch (_state)
        {
            case StateSkill.Ready:
                CheckDistance();
                if (_distanceFromPlayer < minDistanceSkill || _distanceFromPlayer > maxDistanceSkill)
                {
                    return;
                }
                _anim.SetBool(_ChaseAnim, false);
                _anim.SetTrigger(_JAttackAnim);
                break;
            case StateSkill.Cooldown:
                CheckDistance();
                if (_coolDown > 0)
                {
                    _coolDown -= Time.deltaTime;
                    _anim.ResetTrigger(_JAttackAnim);
                    _agent.SetDestination(_player.position);
                    _anim.SetBool(_ChaseAnim, true);
                    Attack();
                    return;
                }
                _state = StateSkill.Ready;
                _coolDown = cooldownSkill;
                break;
        }
    }

    private void Attack()
    {
        CheckDistance();
        if (_distanceFromPlayer <= rangeAttack)
        {
            _anim.SetBool(_ChaseAnim, false);
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

    public void ResetAttackTrigger()
    {
        _anim.ResetTrigger(_AttackAnim);
    }

    public void JumpAttack()
    {
        _isGrounded = Physics.CheckBox(groundCheckPosition.position, boxSize, Quaternion.identity, whatisGround);
        if (_isGrounded)
        {
            transform.DOJump(_player.position, jumpHeight, 1, jumpDuration);
            transform.LookAt(_player.position);
            _state = StateSkill.Cooldown;
        }
    }
    
    private float CheckDistance()
    {
        return _distanceFromPlayer = Vector3.Distance(transform.position, _player.position);
    }

    private void TakeDamage(float damage)
    {
        ShowDamage(damage.ToString());
        _healthPoint -= damage;
        _healthBar.UpdateHealthBar(_healthPoint, stat.MaxHealth);

        if (_healthPoint <= 0)
        {
            _agent.SetDestination(transform.position);
            _state = StateSkill.Dead;
            _healthPoint = 0;
            _anim.SetTrigger(_DeadAnim);
            Destroy(gameObject, 4f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(groundCheckPosition.position, boxSize);
    }

    public void Damage(float damageAmount)
    {
        TakeDamage(damageAmount);
    }
    
    void ShowDamage(string text)
    {
        if (floatingTextPrefab)
        {
            GameObject prefab = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;
        }
    }

    public void SetSpawn()
    {
        transform.position = spawnPoint;
    }
}

public enum StateSkill
{
    Ready,
    Cooldown,
    Dead
}
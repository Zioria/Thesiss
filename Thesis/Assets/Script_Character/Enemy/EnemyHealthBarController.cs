using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBarController : MonoBehaviour
{
    [SerializeField] private StatsEnemyScriptable stat;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private float rangeActive;

    private float _healthPoint;
    private bool _playerInrange;
    private EnemyHealthBar _healthBar;

    private void Awake()
    {
        _healthBar = GetComponentInChildren<EnemyHealthBar>();
    }

    private void Start()
    {
        Initialize();
        _healthBar.UpdateHealthBar(_healthPoint, stat.MaxHealth);
    }

    private void Update()
    {
        HealthBarController();
    }

    private void Initialize()
    {
        _healthPoint = stat.MaxHealth;
    }

    private void HealthBarController()
    {
        _playerInrange = Physics.CheckSphere(transform.position, rangeActive, playerMask);
        if (!_playerInrange)
        {
            _healthBar.gameObject.SetActive(false);
            return;
        }
        _healthBar.gameObject.SetActive(true);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, rangeActive);
    }
}

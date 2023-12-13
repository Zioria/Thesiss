using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthController : MonoBehaviour
{
    [SerializeField] private StatsEnemyScriptable bossStat;
    [SerializeField] private EnemyHealthBar healthBar;
    [SerializeField] private CheckPlayerEntrance checkPEntrance;
    [SerializeField] private CanvasGroup canvasGroup;

    private float _healthPoint;
    public bool IsOpenOnce;

    private void Awake()
    {
        IsOpenOnce = false;
    }

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        _healthPoint = bossStat.MaxHealth;
        healthBar.UpdateHealthBar(_healthPoint, bossStat.MaxHealth);
    }

    public void ShowHealthBar()
    {
        canvasGroup.alpha = 1;
    }

    private void HideHealthBar()
    {
        canvasGroup.alpha = 0;
    }

    public void HideHealthBar_WithTime()
    {
        Invoke(nameof(HideHealthBar), 2f);
    }
    
}

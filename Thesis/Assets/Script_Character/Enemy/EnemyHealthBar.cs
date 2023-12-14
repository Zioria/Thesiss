using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField, Tooltip("Boss Only")] private BossHealthController bossHpController;

    private void Start()
    {
        if (bossHpController == null)
        {
            gameObject.SetActive(false);
        }
    }

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }

    public void ShowHealthBar()
    {
        bossHpController.ShowHealthBar();
    }
}

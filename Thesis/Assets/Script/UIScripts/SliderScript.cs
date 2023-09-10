using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] private Image fillImage;

    private Slider _slider;
    private float fillValue;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Update()
    {
        fillValue = (float)CharacterStats.Instance.CurrentHealth / CharacterStats.Instance.MaxHealth;
        _slider.value = fillValue;
    }
}

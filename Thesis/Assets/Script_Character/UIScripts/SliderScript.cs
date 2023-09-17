using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CharacterStatusUI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] private Image fillImage;

    private Slider _slider;
    private float fillValue;
    private CharacterStats[] stats => Instance.Stats;
    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Update()
    {
        foreach (var stat in stats) 
        { 
            if (stat.gameObject.activeInHierarchy)
            {
                Debug.Log(stat.CurrentHealth);
                fillValue = (float)stat.CurrentHealth / stat.MaxHealth;
                _slider.value = fillValue;
            }
        }
    }
}

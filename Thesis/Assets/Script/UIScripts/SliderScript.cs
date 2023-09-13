using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CharacterStatusUI;

public class SliderScript : MonoBehaviour
{
    [SerializeField, Tooltip("Only Enter Health, Energy")] private string nameObject;
    [SerializeField] private Image fillImage;

    private Slider _slider;
    private float fillValue;
    private CharacterStats[] stats => Instance.Stats;
    private CharacterStats stat;
    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Update()
    {
        stat = Instance.CurrentActive(stats);
        SliderUpdate();
    }

    private void SliderUpdate()
    {
        if (nameObject == "Health")
        {
            fillValue = (float)stat.CurrentHealth / stat.MaxHealth;
        }
        if (nameObject == "Energy")
        {
            fillValue = (float)stat.CurrentCapEnergy / stat.CapEnergy;
        }
        _slider.value = fillValue;
    }
}

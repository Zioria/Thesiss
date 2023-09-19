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
    private float _fillValue;
    private CharacterStats[] _stats => Instance.Stats;
    private CharacterStats _stat;
    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Update()
    {
        _stat = Instance.CurrentActive(_stats);
        SliderUpdate();
    }

    private void SliderUpdate()
    {
        if (nameObject == "Health")
        {
            _fillValue = (float)_stat.CurrentHealth / _stat.MaxHealth;
        }
        if (nameObject == "Energy")
        {
            _fillValue = (float)_stat.CurrentCapEnergy / _stat.CapEnergy;
        }
        _slider.value = _fillValue;
    }
}

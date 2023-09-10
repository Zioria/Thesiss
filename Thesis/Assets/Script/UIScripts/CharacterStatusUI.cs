using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatusUI : MonoBehaviour
{
    [SerializeField] private Text healthText;

    private void Update()
    {
        healthText.text = CharacterStats.Instance.CurrentHealth + " / " + CharacterStats.Instance.MaxHealth;
    }
}

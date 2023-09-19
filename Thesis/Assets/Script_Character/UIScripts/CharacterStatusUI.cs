using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatusUI : MonoBehaviour
{
    public static CharacterStatusUI Instance;
    [SerializeField] private Text healthText;
    [SerializeField] private Text energyText;


    public CharacterStats[] Stats;
    private CharacterStats currentActive;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        ChangeStatsCharacter();
    }

    public void ChangeStatsCharacter()
    {
        CharacterStats stat = CurrentActive(Stats);
        healthText.text = stat.CurrentHealth + " / " + stat.MaxHealth;
        energyText.text = stat.CurrentCapEnergy + " / " + stat.CapEnergy;
    }

    public CharacterStats CurrentActive(CharacterStats[] stats)
    {
        foreach (var stat in stats)
        {
            if (!stat.gameObject.activeInHierarchy)
            {
                continue;
            }
            currentActive = stat;
        }

        return currentActive;
    }
}

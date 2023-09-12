using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatusUI : MonoBehaviour
{
    public static CharacterStatusUI Instance;
    [SerializeField] private Text healthText;



    public CharacterStats[] Stats;

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
        foreach (var stat in Stats)
        {
            if (!stat.gameObject.activeInHierarchy)
            {
                continue;
            }
            healthText.text = stat.CurrentHealth + " / " + stat.MaxHealth;
        }
    }
}

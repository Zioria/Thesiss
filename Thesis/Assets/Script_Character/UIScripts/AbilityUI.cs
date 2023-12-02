using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour
{
    [SerializeField] AbilityHolder holder;

    [Header("AbilityOne")]
    [SerializeField] private Image abilityImageOne;

    private AbilityScriptable abilityStat;

    private void Update()
    {
        Ability();
    }

    private void Ability()
    {
        abilityStat = holder.ability;
        switch (holder.state)
        {
            case AbilityState.ready:
                abilityImageOne.fillAmount = 0;
                break;
            case AbilityState.active:
                abilityImageOne.fillAmount = 1;
                break;
            case AbilityState.cooldown:
                abilityImageOne.fillAmount -= 1 / abilityStat.CoolDownTime * Time.deltaTime;

                if (abilityImageOne.fillAmount <= 0)
                {
                    abilityImageOne.fillAmount = 0;
                }
                break;
        }
    }
}

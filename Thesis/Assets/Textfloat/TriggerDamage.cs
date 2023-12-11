using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    [SerializeField] private float multiplyer = 1;
    private CharacterStats[] _stats => CharacterStatusUI.Instance.Stats;
    private CharacterStats _stat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enermy"))
        {
            IDamagable damagable = other.GetComponent<IDamagable>();
            if (damagable != null)
            {
                _stat = CharacterStatusUI.Instance.CurrentActive(_stats);
                damagable.Damage((_stat.Damage * (multiplyer / 100)) * _stat.SkillDamage);
                _stat.GetEnergy(1);
                Debug.Log(((_stat.Damage * (multiplyer / 100)) * _stat.SkillDamage));
            }
            
        }

        Destroy(gameObject, 1f);
    }
}

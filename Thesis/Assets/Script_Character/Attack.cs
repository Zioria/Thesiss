using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public class Attack : MonoBehaviour
{
    [SerializeField] private float DamageAfterTime;
    [SerializeField] private int Damage;
    [SerializeField] private AttackArea _attackArea;
    
    public void OnAttack(InputValue value)
    {
        Debug.Log("Attack");
        StartCoroutine(Hit());
    }

    private IEnumerator Hit()
    {
        yield return new WaitForSeconds( DamageAfterTime );
        foreach (var attackAreaDamageable in _attackArea.Damageables)
        {
            attackAreaDamageable.Damage(Damage * 1);
        }
    }
   
}

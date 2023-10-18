using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamageMarker : MonoBehaviour
{
    [SerializeField] private float weaponLength;
    [SerializeField] private float weaponDamage;
    [SerializeField] private LayerMask layerMask;

    private bool _canDealDamage;
    private bool _hasDealDamage;
    private CharacterStats[] _stats => CharacterStatusUI.Instance.Stats;
    private CharacterStats _stat;

    private void Start()
    {
        _canDealDamage = false;
        _hasDealDamage = true;
    }

    private void Update()
    {
        CheckRangeWeapon();
    }

    private void CheckRangeWeapon()
    {
        if (_canDealDamage && !_hasDealDamage)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.right, out hit, weaponLength, layerMask))
            {
                _stat = CharacterStatusUI.Instance.CurrentActive(_stats);
                _stat.TakeDamage(weaponDamage);
                _hasDealDamage = !_hasDealDamage;
            }
        }
    }

    public void StartDealDamage()
    {
        _canDealDamage = !_canDealDamage;
        _hasDealDamage = !_hasDealDamage;
    }

    public void EndDealDamage()
    {
        _canDealDamage = !_canDealDamage;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position - transform.right * weaponLength);
    }

}

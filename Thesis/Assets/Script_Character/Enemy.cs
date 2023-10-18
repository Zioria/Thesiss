using Script_Character.Interface;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    public void Damage(int damageAmount)
    {
        Debug.Log($"I got damage - {damageAmount}");
    }
}

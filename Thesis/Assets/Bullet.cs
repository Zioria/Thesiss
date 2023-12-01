using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life;
    public float curAttack;
    private EnemyStat _enemystat;
    
    // Start is called before the first frame update
    void Awake()
    {
        
        
    }

    private void Update()
    {
        curAttack = MCMattack.Instance.attackValue;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enermy"))
        {
            IDamagable damagable = other.GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.Damage(curAttack);
            }
        }

        if (other.CompareTag("Player"))
        {
            return;
        }
        
        Destroy(this.gameObject);
    }
}

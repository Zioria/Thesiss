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

        life -= 1 * Time.deltaTime;
        
        if (life < 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enermy"))
        {
            other.GetComponent<EnemyStat>().TakeDamage(curAttack);
        }
        
        Destroy(this.gameObject);
    }
}

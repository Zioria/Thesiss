using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    [SerializeField] private float healthPoint;

    private Animator _anim;
    private GameObject _player;
    // public static Player Instance;
    // public GameObject questB;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _player = GameObject.FindWithTag("Player");
    }


    public void TakeDamage(float damage)
    {
        healthPoint -= damage;
        _anim.SetTrigger("Damage");

        if (healthPoint <= 0)
        {
            Die();
            Player.Instance.GoBattle(); 
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);

        
    }
}

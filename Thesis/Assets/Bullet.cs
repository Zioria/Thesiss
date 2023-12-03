using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform Target = null;
    [SerializeField] private Rigidbody HomingBBullet;
    

   void Start()
   {
       
       HomingBBullet = GetComponent<Rigidbody>();
       Target = MCMattack.Instance.nearestEnemy;
       if (HomingBBullet == null)
       {
           Debug.LogError("Is NUll");
       }
       
       
   }

   private void FixedUpdate()
   {
       StartCoroutine(MoveToEnemy());
   }

   IEnumerator MoveToEnemy()
   {
       if (Target != null)
       {
           Vector3 direction = Target.position - HomingBBullet.position;
           direction.Normalize();
           yield break;
       }
   }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            return;
        }
        
        Destroy(this.gameObject);
    }
}

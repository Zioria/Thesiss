using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    public Animator anim;
    public float delay = 0.3f;
    private bool attackbool;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            attack();
        }
    }

    public void attack()
    {
        anim.SetTrigger("Attack");
        
    }

    private IEnumerator delayAttack()
    {
        yield return new WaitForSeconds(delay);
    }
}

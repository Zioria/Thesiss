using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npcsetting : MonoBehaviour
{
    public Animator anim; 
    // Start is called before the first frame update
    void Start()
    {
        anim.SetTrigger("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

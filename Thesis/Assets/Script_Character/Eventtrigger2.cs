using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventtrigger2 : MonoBehaviour
{
    public GameObject buttonQD;
    public GameObject offtrigger2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           buttonQD.SetActive(true);
           offtrigger2.SetActive(false);
            
        }   
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject interstatus;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            interstatus.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.V))
        {
            interstatus.SetActive(false);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnSec : MonoBehaviour
{
    [SerializeField] private float secondToDestroy;

    public GameObject mainCam;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(mainCam.transform);
        Destroy(gameObject, secondToDestroy);
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnSec : MonoBehaviour
{
    [SerializeField] private float secondToDestroy;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        //transform.LookAt(transform.position + _camera.transform.rotation * Vector3.forward, _camera.transform.rotation * Vector3.up);
        Destroy(gameObject, secondToDestroy);
    }

    private void LateUpdate()
    {
        transform.LookAt(_camera.transform.position);
        transform.rotation = Quaternion.LookRotation(_camera.transform.forward);
    }

}

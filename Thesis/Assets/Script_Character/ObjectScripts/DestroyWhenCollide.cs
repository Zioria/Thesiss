using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenCollide : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject, .5f);
    }
}

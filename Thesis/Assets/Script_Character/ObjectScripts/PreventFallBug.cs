using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventFallBug : MonoBehaviour
{
    [Header("reference")]
    [SerializeField] private SwapChar sChar;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        sChar.PreventFall();
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        sChar.PreventFall();
    }
}

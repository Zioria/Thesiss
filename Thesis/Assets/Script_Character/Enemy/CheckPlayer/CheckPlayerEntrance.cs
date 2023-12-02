using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerEntrance : MonoBehaviour
{
    public bool IsPlayerEnter;

    private void Start()
    {
        IsPlayerEnter = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        IsPlayerEnter = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        IsPlayerEnter = false;
    }
}

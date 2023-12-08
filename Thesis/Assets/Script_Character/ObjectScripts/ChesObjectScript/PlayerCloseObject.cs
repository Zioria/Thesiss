using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCloseObject : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        Interactor.Instance.IsInteracting = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        Interactor.Instance.IsInteracting = false;
    }
}

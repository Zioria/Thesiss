using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInDomain : MonoBehaviour
{
    public List<Transform> targets;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enermy"))
        {
            return;
        }
        targets.Add(other.transform);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Enermy"))
        {
            return;
        }
        if (targets.Contains(other.transform))
        {
            targets.Remove(other.transform);
        }
    }
}

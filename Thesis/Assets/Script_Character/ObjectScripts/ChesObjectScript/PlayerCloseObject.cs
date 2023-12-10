using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCloseObject : MonoBehaviour
{
    [TextArea(5,5)]
    [SerializeField] private string debugLog;
    [SerializeField] private GameObject[] itemsPrefab;
    [SerializeField] private int amountToSpawn;
    private Transform[] _posItemSpawns;


    private void Awake()
    {
        _posItemSpawns = transform.Find("SpawnItemHolder").GetComponentsInChildren<Transform>();
        if (_posItemSpawns != null)
        {
            for (int i = 0; i < _posItemSpawns.Length; i++)
            {
                debugLog += _posItemSpawns[i].name + "\n";
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        Interactor.Instance.IsInteracting = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        if (!Input.GetKeyDown(KeyCode.F))
        {
            return;
        }

        for (int i = 0; i < amountToSpawn; i++)
        {
            SpawnItem();
        }
        Interactor.Instance.IsInteracting = false;
        Destroy(gameObject);
    }

    private void SpawnItem()
    {
        GameObject prefab = itemsPrefab[Random.Range(0, itemsPrefab.Length)];

        Instantiate(prefab, _posItemSpawns[Random.Range(0, _posItemSpawns.Length)].position, Quaternion.identity);
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

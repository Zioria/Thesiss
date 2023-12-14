using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;

    [SerializeField] private GameObject CheckpointHolder;
    public List<CheckPointScript> CheckpointList;

    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        foreach (CheckPointScript checkpoint in CheckpointHolder.GetComponentsInChildren<CheckPointScript>())
        {
            CheckpointList.Add(checkpoint);
        }

        for (int i = 0; i < CheckpointList.Count; i++)
        {
            CheckpointList[i].ID = i;
        }
    }
}

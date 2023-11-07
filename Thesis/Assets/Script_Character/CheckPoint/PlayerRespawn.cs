using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    
    public static PlayerRespawn Instance;
    private Vector3 playerSpawnpoint;
    public Vector3 PlayerSpawnpoint => playerSpawnpoint;

    private void Awake()
    {
        if (Instance != null)
        {
            Instance = this;
        }

        playerSpawnpoint = gameObject.transform.position;
    }

    public void SetSpawnpoint(Vector3 newSpawnpoint)
    {
        playerSpawnpoint = newSpawnpoint;
    }
}

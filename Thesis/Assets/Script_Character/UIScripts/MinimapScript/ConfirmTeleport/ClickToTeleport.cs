using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class ClickToTeleport : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    [SerializeField] private Button teleportBtn;
    [SerializeField] private GameObject mapHolder;
    [SerializeField] private GameObject miniMap;
    [SerializeField] private CursorControl cursor;
    [SerializeField] private ThirdPersonController playerController;
    [SerializeField] private float timeToReset;
    
    private int _id;
    private PlayerRespawn _playerRespawn;
    private void Awake()
    {
        _playerRespawn = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerRespawn>();
        teleportBtn.onClick.AddListener(() =>
        {
            CheckSpawnpoint();
            mapHolder.SetActive(false);
            miniMap.SetActive(true);
            cursor.CloseMenu();
        });
    }

    private void CheckSpawnpoint()
    {

        for (int i = 0; i < CheckpointManager.Instance.CheckpointList.Count; i++)
        {
            if (i != LargeMapPointer.Instance.ID)
            {
                continue;
            }
            playerController.IsDisable = true;
            playerObject.transform.position = CheckpointManager.Instance.CheckpointList[i].SpawnPoint.position;
            _playerRespawn.SetSpawnpoint(CheckpointManager.Instance.CheckpointList[i].SpawnPoint.position);
            Invoke(nameof(ResetPlayerController), timeToReset);
        }
    }

    private void ResetPlayerController()
    {
        playerController.IsDisable = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject confirmTeleport;
    [SerializeField] private GameObject flagHolder;
    [SerializeField] private string namePosition;

    private SpriteRenderer _spriteRen;
    private MeshRenderer _objectTexture;
    private BoxCollider _boxCollider;

    public string NamePosition => namePosition;
    public Transform SpawnPoint => spawnPoint;
    public bool _isActive;
    public int ID;

    private void Awake()
    {
        _isActive = false;
        _objectTexture = GetComponentInChildren<MeshRenderer>();
        _boxCollider = GetComponentInChildren<BoxCollider>();
        _spriteRen = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        other.GetComponent<PlayerRespawn>().SetSpawnpoint(spawnPoint.position);
        _isActive = true;
        _spriteRen.color = Color.blue;
        _boxCollider.enabled = false;
        _objectTexture.enabled = false;
        flagHolder.SetActive(true);
    }

    public void PlayerClick()
    {
        if (_isActive)
        {
            confirmTeleport.SetActive(true);
        }
    }

    public int GetID()
    {
        return ID;
    }
}

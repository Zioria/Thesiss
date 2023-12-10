using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickup : MonoBehaviour
{
    
    [SerializeField] private ItemScriptable itemData;
    [SerializeField] private float speedRotateItem = 20;

    private void Update()
    {
        transform.Rotate(Vector3.up * speedRotateItem * Time.deltaTime);
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
        if (!Input.GetKeyDown(KeyCode.F))
        {
            return;
        }

        var inventory = other.transform.GetComponent<PlayerInventoryHolder>();

        if (!inventory) return;

        if (inventory.AddToInventory(itemData, 1))
        {
            Destroy(gameObject);
            Interactor.Instance.IsInteracting = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Interactor.Instance.IsInteracting = false;
    }
}

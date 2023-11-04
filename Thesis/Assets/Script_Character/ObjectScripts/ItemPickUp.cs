using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private ItemScriptable item;

    private GameObject _itemLogHolder;
    private Animator _itemLogAnimator;
    private Text _itemLogText;
    private Queue<string> _popupQueue;
    private Coroutine _queueCheker;

    private void Awake()
    {
        _itemLogHolder = GameObject.Find("UI/ItemLogHolder");
        _itemLogAnimator = _itemLogHolder.GetComponent<Animator>();
        _itemLogText = _itemLogHolder.GetComponentInChildren<Text>();
        _popupQueue = new Queue<string>();
    }

    private void Start()
    {
        _itemLogHolder.SetActive(false);
    }

    private void PickUp()
    {
        InventoryManager.Instance.Add(item);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        AddToQueue(itemName);
        PickUp();
    }

    private IEnumerator CheckQueue()
    {
        do
        {
            ShowPopup(_popupQueue.Dequeue());
            do
            {
                yield return null;
            } while (!_itemLogAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Idle"));
        } while (_popupQueue.Count > 0);

        _itemLogHolder.SetActive(false);
    }

    private void AddToQueue(string text)
    {
        _popupQueue.Enqueue(text);

        if (_queueCheker != null)
        {
            return;
        }
        _queueCheker = StartCoroutine(CheckQueue());
    }

    private void ShowPopup(string text)
    {
        _itemLogHolder.SetActive(true);
        _itemLogText.text = "Pick Up: " + text;
        _itemLogAnimator.Play("ItemLog");
    }

}

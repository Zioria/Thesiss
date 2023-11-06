using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public static WaypointManager Instance;
    public List<Transform> Children => _children;

    private List<Transform> _children;

    [SerializeField] private Transform waypointParent;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        if (_children != null)
        {
            return;
        }
        _children = GetChildren(waypointParent);

        //foreach (Transform child in _children)
        //{
        //    Debug.Log(child.name);
        //}
    }

    private List<Transform> GetChildren(Transform parent)
    {
        _children = new List<Transform>();

        foreach (Transform child in parent)
        {
            _children.Add(child);
        }
        return _children;
    }
}

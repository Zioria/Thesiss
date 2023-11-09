using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FollowPosition))]
public class CameraDragAndZoom : MonoBehaviour
{
    [SerializeField] private Camera largeCam;
    [SerializeField] private GameObject largeMinimap;
    [SerializeField] private float dragSpeed;

    private FollowPosition _followScipt;
    private Vector2 _dragOrigin;
    private bool _isDrag;
    private void Awake()
    {
        _isDrag = false;
        _followScipt = GetComponent<FollowPosition>();
    }

    private void Update()
    {
        Vector3 inputDir = Vector3.zero;
        if (!largeMinimap.activeInHierarchy)
        {
            _followScipt.enabled = true;
            return;
        }

        CheckMouseIsPress();

        if (_isDrag)
        {
            Vector2 mouseMovemennt = (Vector2)Input.mousePosition - _dragOrigin;

            inputDir.x = mouseMovemennt.x * dragSpeed;
            inputDir.z = mouseMovemennt.y * dragSpeed;

            _dragOrigin = Input.mousePosition;
        }

        Vector3 moveDir = -transform.up * inputDir.z + -transform.right * inputDir.x;
        transform.position += moveDir * Time.deltaTime;
    }

    private void CheckMouseIsPress()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isDrag = true;
            _followScipt.enabled = false;
            _dragOrigin = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _isDrag = false;
        }
    }
}

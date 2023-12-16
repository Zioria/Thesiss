using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(FollowPosition))]
public class CameraDragAndZoom : MonoBehaviour
{
    [TextArea(4,4)]
    [SerializeField] private string DEBUG_LOG;

    [SerializeField] private Camera largeCam;
    [SerializeField] private MapHolderUI mHolderUI;
    [SerializeField] private GameObject largeMinimap;
    [SerializeField] private float dragSpeed;
    [SerializeField] private float nearMapDragSpeed;
    [SerializeField] private GameObject ZoomBar;
    [SerializeField] private float _maxZoom;
    [SerializeField] private float _minZoom;
    [SerializeField] private float panSpeed;
    [SerializeField] private float cameraSpeed;

    private FollowPosition _followScipt;
    private Vector3 _dragOrigin;
    private Vector3 _difference;
    private bool _isDragging;
    private float _amountZoom;
    private Vector3 GetMousePosition => largeCam.ScreenToWorldPoint(Input.mousePosition);

    private void Awake()
    {
        _amountZoom = largeCam.orthographicSize;
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
        InputScollWheel(largeCam.orthographicSize / 4);
        largeCam.orthographicSize = _amountZoom;
        ZoomBar.GetComponent<Slider>().value = _amountZoom;
        

    }

    private void LateUpdate()
    {

        OnDrag();
        if (!_isDragging || !mHolderUI.IsOpen)

        {
            return;
        }
        _followScipt.enabled = false;
        _difference = GetMousePosition - transform.position;
        transform.position = _dragOrigin - _difference;
    }

    private void OnDrag()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _dragOrigin = GetMousePosition;
        }

        _isDragging = Input.GetMouseButton(0);
    }


    private void InputScollWheel(float amout)
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {
            _amountZoom += amout;
            if (_amountZoom > _maxZoom)
            {
                _amountZoom = _maxZoom;
            }
        }

        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {
            _amountZoom -= amout;
            if (_amountZoom < _minZoom)
            {
                _amountZoom = _minZoom;
            }
        }
    }

    public void SliderZoom(float zoom)
    {
        _amountZoom = zoom;
    }


}

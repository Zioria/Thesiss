using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(FollowPosition))]
public class CameraDragAndZoom : MonoBehaviour
{
    [SerializeField] private Camera largeCam;
    [SerializeField] private GameObject largeMinimap;
    [SerializeField] private float dragSpeed;
    [SerializeField] private float nearMapDragSpeed;
    [SerializeField] private CheckZoom checkZoom;
    [SerializeField] private GameObject ZoomBar;
    [SerializeField] private float _maxZoom;
    [SerializeField] private float _minZoom;

    private FollowPosition _followScipt;
    private Vector2 _dragOrigin;
    private bool _isDrag;
    private float _amountZoom;
    private bool _isNearMap;
    private void Awake()
    {
        _isNearMap = false;
        _amountZoom = largeCam.orthographicSize;
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
        InputScollWheel(largeCam.orthographicSize / 4);
        largeCam.orthographicSize = _amountZoom;
        ZoomBar.GetComponent<Slider>().value = _amountZoom;
        if (_amountZoom < _maxZoom / 2)
        {
            _isNearMap = true;
        }
        if (_amountZoom >= _maxZoom)
        {
            _isNearMap = false;
        }
        if (checkZoom.isZoom)
        {
            return;
        }
        CheckMouseIsPress();

        if (_isDrag)
        {
            Vector2 mouseMovemennt = (Vector2)Input.mousePosition - _dragOrigin;

            inputDir.x = mouseMovemennt.x * (_isNearMap? nearMapDragSpeed: dragSpeed);
            inputDir.z = mouseMovemennt.y * (_isNearMap ? nearMapDragSpeed : dragSpeed);

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

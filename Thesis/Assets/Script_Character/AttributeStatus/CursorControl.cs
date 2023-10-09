using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class CursorControl : MonoBehaviour
{
    private bool IsStatusMenuOpen;
    public ThirdPersonController Controller;
    private void Awake()
    {
        IsStatusMenuOpen = false;
        Cursor.visible = IsStatusMenuOpen;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt) || IsStatusMenuOpen)
        {
            Controller.LockCameraPosition = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            return;
        }
        Controller.LockCameraPosition = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OpenMenu()
    {
        IsStatusMenuOpen = !IsStatusMenuOpen;
        Cursor.visible = IsStatusMenuOpen;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseMenu()
    {
        IsStatusMenuOpen = !IsStatusMenuOpen;
        Cursor.visible = IsStatusMenuOpen;
        Cursor.lockState = CursorLockMode.Locked;
    }
}

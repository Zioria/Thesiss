using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControl : MonoBehaviour
{
    private bool IsStatusMenuOpen;

    private void Awake()
    {
        IsStatusMenuOpen = false;
        Cursor.visible = IsStatusMenuOpen;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            Cursor.visible = !Cursor.visible;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void OpenStatusMenu()
    {
        IsStatusMenuOpen = !IsStatusMenuOpen;
        Cursor.visible = IsStatusMenuOpen;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseStatusMenu()
    {
        IsStatusMenuOpen = !IsStatusMenuOpen;
        Cursor.visible = IsStatusMenuOpen;
        Cursor.lockState = CursorLockMode.Locked;
    }
}

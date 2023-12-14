using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorControl : MonoBehaviour
{
    private bool IsStatusMenuOpen;
    [SerializeField] ThirdPersonController Controller;
    [SerializeField] private PlayerInput playerInput;
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
            Time.timeScale = 0;
            return;
        }
        Controller.LockCameraPosition = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    public void OpenMenu()
    {
        Debug.Log("OpenMenu");
        IsStatusMenuOpen = true;
        Time.timeScale = 0;
        Cursor.visible = IsStatusMenuOpen;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseMenu()
    {
        IsStatusMenuOpen = false;
        Time.timeScale = 1;
        Cursor.visible = IsStatusMenuOpen;
        Cursor.lockState = CursorLockMode.Locked;
    }
}

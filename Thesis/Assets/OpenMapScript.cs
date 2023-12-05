using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class OpenMapScript : MonoBehaviour
{

    [SerializeField] private GameObject MapPic;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MapPic.activeInHierarchy)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("MapOpen");
        }
        else if (!MapPic.activeInHierarchy)
        {
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Debug.Log("MapClose");
        }
    }

    public void OnMap(InputValue value)
    {
        MapPic.SetActive(!MapPic.activeSelf);
    }
}

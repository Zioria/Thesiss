using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndUI : MonoBehaviour
{
    [SerializeField] private CursorControl showcursor;

    void Start()
    {
        
    }

    public void ShowUI()
    {
        showcursor.OpenMenu();
    }



    
}

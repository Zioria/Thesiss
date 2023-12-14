using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributePointManager : MonoBehaviour
{
    public static AttributePointManager Instance;

    public int Point;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowYRotation : MonoBehaviour
{
    [SerializeField] private Transform targetCam;

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(90, targetCam.eulerAngles.y, 0);
    }
}

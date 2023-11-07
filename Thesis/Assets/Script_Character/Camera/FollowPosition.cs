using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPosition : MonoBehaviour
{
    [SerializeField] private Transform targetPos;
    [SerializeField] private float offSetZ, offSetX;
    [SerializeField] private float lerpSpeed;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(targetPos.position.x + offSetX, transform.position.y, 
            targetPos.position.z + offSetZ), lerpSpeed);
    }
}

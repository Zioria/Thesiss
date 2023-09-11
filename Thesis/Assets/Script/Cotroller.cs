using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cotroller : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    
    private float speed => CharacterStats.Instance.AtkSpeed;
    public float zero = 0f;
    public float turnSmoothTime = 0.1f;
    private float turnSmootVelocity;
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal,  vertical , 0f).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmootVelocity,
                turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir * speed * Time.deltaTime);
        }
    }
}

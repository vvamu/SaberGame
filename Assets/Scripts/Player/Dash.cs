using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float dashSpeed;
    public float cooldownTime;
    float lastDashTime;
    Rigidbody rig;
    bool isDashing;
    Vector3 dashDirection;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void Dashing()
    {
        var directon = transform.rotation * dashDirection * dashSpeed;
        rig.AddForce(directon, ForceMode.Impulse);
        isDashing = false;
        lastDashTime = Time.time;
    }

    void Update()
    {
        if (Time.time > lastDashTime + cooldownTime)
        {
            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                dashDirection = Vector3.forward;
                isDashing = true;
            }
           
        }
    }
       
    private void FixedUpdate()
    {
        if (isDashing)
            Dashing();
    }
}

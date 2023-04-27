using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float dashSpeed;
    public float cooldownTime;
    public float dashDuration;
    float lastDashTime;
    Rigidbody rig;
    bool isDashing;
    Vector3 dashDirection;
    Vector3 targetVelocity; 

    public static Dictionary<KeyCode, Action> keyboard = new Dictionary<KeyCode, Action>();

    void Start()
    {
        rig = GetComponent<Rigidbody>();

        keyboard.Add(KeyCode.A, DashLeft);
        keyboard.Add(KeyCode.D, DashRight);
        keyboard.Add(KeyCode.W, DashForward);
    }

    private void Dashing()
    {
        float elapsedTime = Time.time - lastDashTime;
        float t = Mathf.Clamp01(elapsedTime / dashDuration); 
        var directon = Vector3.Lerp(Vector3.zero, targetVelocity, t); 
        rig.AddForce(directon, ForceMode.Impulse);
        if (t >= 1f) 
        {
            isDashing = false;
        }
    }

    void Update()
    {
        foreach (var keyCode in keyboard)
        {
            if (Time.time > lastDashTime + cooldownTime)
            {
                if ((Input.GetKey(keyCode.Key)) && (Input.GetKeyDown(KeyCode.LeftAlt)))
                {
                    keyCode.Value();
                    isDashing = true;
                    lastDashTime = Time.time;
                    targetVelocity = transform.rotation * dashDirection.normalized * dashSpeed; 
                }

            }
        }
    }

    private void DashLeft()
    {
        dashDirection = Vector3.left;
    }
    private void DashRight()
    {
        dashDirection = Vector3.right;
    }
    private void DashForward()
    {
        dashDirection = Vector3.forward;
    }

    private void FixedUpdate()
    {
        if (isDashing)
            Dashing();
    }
}

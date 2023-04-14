using OpenCover.Framework.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float dashSpeed;
    Rigidbody rig;
    bool isDashing;
    Vector3 dashDirection;

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
        var directon = transform.rotation * dashDirection * dashSpeed;
        rig.AddForce(directon, ForceMode.Impulse);
        isDashing = false;
    }

    private float lastClickTime;
    private const float DOUBLE_CLICK_TIME = .2f;

    void Update()
    {
        foreach (var keyCode in keyboard)
        {

            if (Input.GetKeyDown(keyCode.Key))
            {
                float timeSinceLastClick = Time.time - lastClickTime;

                if (timeSinceLastClick <= DOUBLE_CLICK_TIME)
                {
                    isDashing = true;
                    keyCode.Value();
                }

                lastClickTime = Time.time;
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

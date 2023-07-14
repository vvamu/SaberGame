using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GrenadeThrower : MonoBehaviour
{
    public float grenadeReload = 2.0f;
    public float throwForce = 50f;
    public GameObject grenadePrefab;
    public GameObject camera;

    bool canThrow = true;
    bool TimerOn = false;
    float Timer = 0;

    void Update()
    {
        if (TimerOn)
        {
            if (grenadeReload >= Timer)
            {
                Timer += Time.deltaTime;
                EventBus.onGrenadeReload?.Invoke(Timer, grenadeReload);
            }
            else
            {
                Timer = 0;
                TimerOn = false;
            }
        }
        else
        {
            if (canThrow && Input.GetKey(KeyCode.G))
            {
                GameObject grenade = Instantiate(grenadePrefab, camera.transform.position, camera.transform.rotation);
                Rigidbody rigidbody = grenade.GetComponent<Rigidbody>();
                rigidbody.AddForce(camera.transform.forward * throwForce, ForceMode.VelocityChange);
                TimerOn = true;
            }
        }
    }
}

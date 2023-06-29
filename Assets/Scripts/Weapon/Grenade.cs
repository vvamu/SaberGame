using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float flyDelay = 2.0f;
    public float dragDecay = 3.0f;
    public GameObject explosionEffect;
    public GameObject dragEffect;
    public float radius = 20f;
    public float force = 500f;
    public float damage = 1000f;

    float countdown;
    bool isExpolde = false;
    bool drag = false;
    Collider[] colliders;
    Rigidbody rb;
    Vector3 pos;


    void Start()
    {
        countdown = flyDelay;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown < 0 && !isExpolde)
        {
            drag = true;
            isExpolde=true;
            pos = transform.position;
            GameObject dragvfx = Instantiate(dragEffect, pos, transform.rotation);
            countdown = dragDecay;
            rb.isKinematic = true;
            Destroy(dragvfx, dragDecay);     
        }

        if(drag)
        {
            colliders = Physics.OverlapSphere(pos, radius);
            foreach (Collider collider in colliders)
            {
                Rigidbody rb = collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(force * Time.deltaTime, pos, radius);
                }
            }
        }

        if (countdown < 0 && drag)
        {
            colliders = Physics.OverlapSphere(pos, radius);
            Instantiate(explosionEffect, pos, transform.rotation);

            foreach (Collider collider in colliders)
            {
                Enemy enemy = collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            }

            Destroy(gameObject);
        }
    }
}

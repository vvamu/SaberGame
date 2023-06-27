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
    Vector3 pos;

    void Start()
    {
        countdown = flyDelay;
    }

    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown < 0 && !isExpolde)
        {
            drag = true;
            isExpolde=true;
            pos = transform.position;
            colliders = Physics.OverlapSphere(transform.position, radius);
            Instantiate(dragEffect, transform.position, transform.rotation);
            countdown = dragDecay;
        }

        if(drag)
        {
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

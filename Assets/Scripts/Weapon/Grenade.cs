using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float flyDelay;
    public float dragDecay;
    public GameObject explosionEffect;
    public GameObject dragEffect;
    public float radius;
    public float force;
    public float damage;

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
                Player pl = collider.GetComponentInParent<Player>();
                if (rb != null && pl == null)
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

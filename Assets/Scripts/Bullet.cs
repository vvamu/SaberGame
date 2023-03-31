using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Gun _gun;

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.collider.CompareTag("Enemy"))
        //{
        //    Debug.Log("true");
        //}
        //else 
        //{ 
        //    Debug.Log("false"); 
        //}
        if(gameObject.GetComponent<Bullet>() != null)
        Destroy(gameObject);

        //enemy?.TakeDamage(Convert.ToInt32(_gun.Damage));
    }
}

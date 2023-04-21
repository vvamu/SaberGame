using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Weapon
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private GameObject _hitParticle;


        private void FixedUpdate()
        {
            transform.Translate(0, 0, _speed);
        }
        private void OnCollisionEnter(Collision collision)
        {
            GameObject col = collision.gameObject;
            if (col.CompareTag("Wall"))
            {
                GameObject particle = GameObject.Instantiate(_hitParticle, transform.position, Quaternion.identity, col.transform);
                Destroy(gameObject);
            }
           
        }
    }
}

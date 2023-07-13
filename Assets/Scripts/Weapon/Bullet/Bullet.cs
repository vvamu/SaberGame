using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Weapon.Bullet
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private LayerMask _collisonMask;
        [SerializeField] private float _damage;

        private void OnTriggerEnter(Collider collision)
        {
            if (((1 << collision.gameObject.layer) & _collisonMask) > 0)
            {
                if(collision.gameObject.TryGetComponent(out Character character))
                {
                    character.TakeDamage(_damage);
                }
                Destroy(gameObject);
            }
        }
    }
}
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Weapon.Bullet
{
    public class BoxBullet : MonoBehaviour
    {
        [SerializeField] private LayerMask _collisonMask;
        [SerializeField] private float _damage;
        [SerializeField] private float _lifeTime;

        private void OnTriggerEnter(Collider collision)
        {
            if (((1 << collision.gameObject.layer) & _collisonMask) > 0)
            {
                if (collision.gameObject.TryGetComponent(out Character character))
                {
                    character.TakeDamage(_damage);
                }
            }
        }

        private void Start()
        {
            Destroy(gameObject, _lifeTime);
        }
    }
}
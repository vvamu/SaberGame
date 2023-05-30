using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Weapon.Attack
{
    public class PhysicAttack : WeaponAttack
    {
        [SerializeField] private float _force;
        [SerializeField] private GameObject _bullet;
        public override void Attack(Vector3 position, Vector3 direction)
        {
            var bullet = Instantiate(_bullet, position, Quaternion.LookRotation(-direction)); //TODO
            bullet.GetComponent<Rigidbody>().AddForce(direction.normalized*_force, ForceMode.VelocityChange);
        }
    }
}
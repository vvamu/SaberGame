using Assets.Scripts.Weapon.Bullet;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Weapon.Attack
{
    public class BoxAttack : WeaponAttack
    {
        [SerializeField] private GameObject _bullet;
        public override void Attack(Vector3 position, Vector3 direction)
        {
            var bullet = Instantiate(_bullet, position, Quaternion.LookRotation(-direction), transform); //TODO
        }
    }
}
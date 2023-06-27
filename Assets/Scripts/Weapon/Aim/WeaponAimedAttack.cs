using Assets.Scripts.Weapon.Attack;
using Assets.Scripts.Weapon.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Weapon.Aim
{
    public class WeaponAimedAttack : MonoBehaviour, IWeaponAim
    {
        [SerializeField] private WeaponAttack _weaponAttack;

        private Vector3 _position;
        private Vector3 _direction;

        public void SetShootPositionAndDirection(Vector3 position, Vector3 direction)
        {
            _position = position;
            _direction = direction;
        }

        public void AimendAttack()
        {
            _weaponAttack.Attack(_position, _direction);
        }
    }
}
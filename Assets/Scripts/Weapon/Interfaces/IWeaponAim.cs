using UnityEngine;

namespace Assets.Scripts.Weapon.Interfaces
{
    public interface IWeaponAim
    {
        void AimendAttack();
        void SetShootPositionAndDirection(Vector3 position, Vector3 direction);
    }
}
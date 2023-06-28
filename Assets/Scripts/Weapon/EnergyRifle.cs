using Assets.Scripts.Weapon.Aim;
using Assets.Scripts.Weapon.Attack;
using Assets.Scripts.Weapon.Interfaces;
using Assets.Scripts.Weapon.Trigger;
using UnityEngine;

namespace Assets.Scripts.Weapon
{
    public class EnergyRifle : BaseWeapon
    {
        [SerializeField]
        private AutomaticTrigger _trigger;

        [SerializeField]
        private MagazineWeaponAttack _magazine;

        [SerializeField]
        private WeaponAimedAttack _aim;

        [SerializeField]
        private WeaponAmmo _weaponAmmo;

        public override IWeaponAim Aim => _aim;
        public override IWeaponMagazine Magazine => _magazine;
        public override ITrigger MainFire => _trigger;

        public void Awake()
        {
            if (_magazine != null)
            {
                _weaponAmmo = Instantiate(_weaponAmmo);
                _magazine._weaponAmmo = _weaponAmmo;
            }
        }
    }
}
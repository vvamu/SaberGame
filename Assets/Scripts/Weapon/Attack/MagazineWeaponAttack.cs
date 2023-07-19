using Assets.Scripts.Weapon.Interfaces;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Weapon.Attack
{
    public class MagazineWeaponAttack : WeaponAttack, IWeaponMagazine
    {
        [SerializeField] private WeaponAttack _weaponAttack;
        [SerializeField] private int _magazineCapacity = 10;
        [NonSerialized] public WeaponAmmo _weaponAmmo;

        [SerializeField] private UnityEvent<int, int, int, int> _onAmountChange;

        private void Awake()
        {
            _ammoInMagazine = _magazineCapacity;
        }

        private int _ammoInMagazine;

        public int AmmoInMagazine => _ammoInMagazine;
        public UnityEvent<int, int, int, int> OnAmountChange => _onAmountChange;

        public override void Attack(Vector3 position, Vector3 direction)
        {
            if (_ammoInMagazine == 0) return;

            _ammoInMagazine--;
            OnAmountChange.Invoke(_ammoInMagazine, _magazineCapacity, _weaponAmmo.CurrentAmount, _weaponAmmo.MaxAmount);

            _weaponAttack.Attack(position, direction);
        }

        public void Reload()
        {
            if(_weaponAmmo.CurrentAmount == 0) return;

            _weaponAmmo.CurrentAmount += _ammoInMagazine;
            _weaponAmmo.CurrentAmount -= _magazineCapacity;
            _ammoInMagazine = _magazineCapacity;

            OnAmountChange.Invoke(_ammoInMagazine, _magazineCapacity, _weaponAmmo.CurrentAmount, _weaponAmmo.MaxAmount);
        }

        void Start()
        {
            OnAmountChange.Invoke(_ammoInMagazine, _magazineCapacity, _weaponAmmo.CurrentAmount, _weaponAmmo.MaxAmount);
        }
    }
}
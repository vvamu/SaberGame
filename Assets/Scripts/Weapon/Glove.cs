using Assets.Scripts.Weapon;
using Assets.Scripts.Weapon.Aim;
using Assets.Scripts.Weapon.Attack;
using Assets.Scripts.Weapon.Interfaces;
using Assets.Scripts.Weapon.Trigger;
using System.Collections;
using UnityEngine;

public class Glove : BaseWeapon
{
        [SerializeField]
        private SingleTrigger _trigger;
        [SerializeField]
        private WeaponAimedAttack _aim;

        public override IWeaponAim Aim => _aim;
        public override ITrigger MainFire => _trigger;
}
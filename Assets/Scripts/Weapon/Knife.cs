﻿using Assets.Scripts.Weapon.Aim;
using Assets.Scripts.Weapon.Attack;
using Assets.Scripts.Weapon.Interfaces;
using Assets.Scripts.Weapon.Trigger;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Weapon
{
    public class Knife : BaseWeapon
    {

        [SerializeField]
        private AutomaticTrigger _trigger;

        [SerializeField]
        private WeaponAimedAttack _aim;

        public override IWeaponAim Aim => _aim;

        public override ITrigger MainFire => _trigger;
    }
}
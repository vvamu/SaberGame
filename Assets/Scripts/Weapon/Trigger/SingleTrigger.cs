using Assets.Scripts.Weapon.Aim;
using Assets.Scripts.Weapon.Interfaces;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Weapon.Trigger
{
    public class SingleTrigger : TriggerPull
    {
        [SerializeField]
        private WeaponAimedAttack Aim;
        public override void Press()
        {
            Aim.AimendAttack();
        }

        public override void Release()
        {
            
        }
    }
}
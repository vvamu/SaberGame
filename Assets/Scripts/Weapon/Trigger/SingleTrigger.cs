using Assets.Scripts.Weapon.Interfaces;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Weapon.Trigger
{
    public class SingleTrigger : TriggerPull
    {
        public IWeaponAim Aim { get; set; }
        public override void Press()
        {
            Aim.AimendAttack();
        }

        public override void Release()
        {
            
        }
    }
}
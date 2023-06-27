using Assets.Scripts.Weapon.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Weapon
{
    public abstract class BaseWeapon : MonoBehaviour
    {
        public virtual ITrigger MainFire => null;
        public virtual IWeaponAim Aim => null;
        public virtual IWeaponMagazine Magazine => null;
    }
}
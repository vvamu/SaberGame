using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Weapon.Interfaces
{
    public interface IWeaponMagazine
    {
        void Reload();

        UnityEvent<int, int, int, int> OnAmountChange { get; }
    }
}
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Weapon.Attack
{
    public abstract class WeaponAttack : MonoBehaviour
    {
        public abstract void Attack(Vector3 position, Vector3 direction);
    }
}
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Weapon.Attack
{
    public class AnimatedAttack : WeaponAttack
    {
        [SerializeField] private WeaponAttack _weaponAttack;
        [SerializeField] private Animator _animator;
        [SerializeField] private string _triggerName;

        public override void Attack(Vector3 position, Vector3 direction)
        {
            _weaponAttack.Attack(position, direction);
            _animator.SetTrigger(_triggerName);
        }
    }
}
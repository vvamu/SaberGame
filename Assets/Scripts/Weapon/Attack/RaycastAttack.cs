using NodeCanvas.Tasks.Actions;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Weapon.Attack
{
    public class RaycastAttack : WeaponAttack
    {
        [SerializeField] private GameObject _bullet;
        public override void Attack(Vector3 position, Vector3 direction)
        {

            if (Physics.Raycast(position, direction, out RaycastHit hit))
            {
                var bullet = Instantiate(_bullet, hit.point, Quaternion.identity);
            }

        }
    }
}
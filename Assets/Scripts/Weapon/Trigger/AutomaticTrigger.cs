using Assets.Scripts.Weapon.Aim;
using UnityEngine;

namespace Assets.Scripts.Weapon.Trigger
{
    public class AutomaticTrigger : TriggerPull
    {
        [SerializeField]
        private WeaponAimedAttack Aim;

        [Min(0.01f)]
        [SerializeField]
        private float Cooldown;

        private bool _pressed;
        private float _previuseFire;
        public override void Press()
        {
            _pressed = true;
        }

        public override void Release()
        {
            _pressed = false;
        }

        private void Awake()
        {
            _previuseFire = Time.time;
        }

        void Update()
        {
            if (!_pressed) return;
            if ((Time.time - _previuseFire) < Cooldown) return;
            _previuseFire = Time.time;

            Aim.AimendAttack();
        }
    }
}
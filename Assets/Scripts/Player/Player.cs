using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class Player : Character
    {
        [SerializeField] protected UnityEvent<float, float> onShieldChange;
        [SerializeField] protected UnityEvent<float, float> onHealthChange;

        [SerializeField] public float RegenerationCountHP;
        [SerializeField] public float RegenerationDecayHP;
        [SerializeField] public float RegenerationCountShield;
        [SerializeField] public float RegenerationDecayShield;
        [SerializeField] public float Shield;
        [SerializeField] public float MaxShield;

        bool TimerOnHP = false;
        bool TimerOnShield = false;

        float TimerHP = 0;
        float TimerShield = 0;
        public override float TakeDamage(float damage)
        {
            if (Shield >= 0)
            {
                if (TimerOnShield)
                {
                    TimerOnShield = false;
                }
                Shield -= damage;
                onShieldChange.Invoke(Shield, MaxShield);
                TimerOnShield = true;
                return 0;
            }
            else
            {
                if (TimerOnHP)
                {
                    TimerOnHP = false;
                }
                TimerOnHP = true;
                onHealthChange.Invoke(Health, MaxHealth);
                return base.TakeDamage(damage);
            }
        }
        void Start()
        {
            onHealthChange.Invoke(Health, MaxHealth);
            onShieldChange.Invoke(Shield, MaxShield);
        }

        void Update()
        {
            //shield timer
            if (TimerOnShield)
            {
                if (RegenerationDecayShield >= TimerShield)
                {
                    TimerShield += Time.deltaTime;
                }
                else
                {
                    TimerShield = 0;
                    TimerOnShield = false;
                }
            }
            else
            {
                if (Shield < MaxShield)
                {
                    Shield += RegenerationCountShield * Time.deltaTime;
                    onShieldChange.Invoke(Shield, MaxShield);
                }
            }

            //hp timer
            if (TimerOnHP)
            {
                if (RegenerationDecayHP >= TimerHP)
                {
                    TimerHP += Time.deltaTime;
                }
                else
                {
                    TimerHP = 0;
                    TimerOnHP = false;
                }
            }
            else
            {
                if (Health<MaxHealth)
                {
                    Health += RegenerationCountHP * Time.deltaTime;
                    onHealthChange.Invoke(Health, MaxHealth);
                }
            }
        }
    }
}

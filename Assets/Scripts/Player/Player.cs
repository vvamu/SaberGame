using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : Character
    {
        [SerializeField] public float RegenerationCount;
        [SerializeField] public float RegenerationDecay;
        [SerializeField] public float MaxHealth;

        bool TimerOn = false;
        float Timer = 0;
        public override float TakeDamage(float damage)
        {
            TimerOn = true;
            return base.TakeDamage(damage);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                TakeDamage(42);
            }
            if(TimerOn)
            {
                if (RegenerationDecay >= Timer)
                {
                    Timer += Time.deltaTime;
                }
                else
                {
                    Timer = 0;
                    TimerOn = false;
                }
            }
            else
            {
                if (Health<MaxHealth)
                {
                    Health += RegenerationCount * Time.deltaTime;
                }
            }
        }
    }
}

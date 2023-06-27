using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class Character : MonoBehaviour
    {
        [SerializeField] protected UnityEvent<float, float> onHealthChange;


        [Min(0)]
        [SerializeField] public float Health;
        [SerializeField] public float MaxHealth;
        public virtual float TakeDamage(float damage)
        {
            Health -= damage;
            onHealthChange.Invoke(Health, MaxHealth);
            if (Health < 0)
                Destroy(gameObject);
            //    OnDeath.Invoke();
            return Health;
        }
    }
}

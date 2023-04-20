﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public abstract class Character : MonoBehaviour
    {
        [SerializeField] protected UnityEvent OnDeath;

        [Min(0)]
        [SerializeField] public float Health;
        public virtual float TakeDamage(float damage)
        {
            Health -= damage;
            if (Health <= 0)
                OnDeath.Invoke();
            //UnityEngine.Debug.Log("Take damage " + Health.ToString());
            return Health;
        }
    }
}

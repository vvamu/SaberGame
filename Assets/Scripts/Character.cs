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
        [Min(0)]
        [SerializeField] public float Health;
        [SerializeField] public float MaxHealth;
        public DeathManager _deathManager;
        public bool isEnemy = true;
        public event Action OnDeath;
        public void Start(){
            if(TryGetComponent<DeathManager>(out var deathManager))
                {
                    OnDeath += deathManager.DeathCallback;
                    isEnemy = false;
                }
        }
        public virtual float TakeDamage(float damage)
        {
            Health -= damage;
            if (Health <= 0)
                {
                    OnDeath.Invoke();
                    if(isEnemy) Destroy(gameObject);
                }
            return Health;
        }
    }
}

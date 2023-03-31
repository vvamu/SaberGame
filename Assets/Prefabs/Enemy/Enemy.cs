using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public List<Transform> Path;
    public EnemyVision enemyVision;
    
    [SerializeField] private UnityEvent OnDeath;

    [Min(0)]
    [SerializeField] private int Health;


    public int TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0)
            OnDeath.Invoke();
        return Health;
    }
}

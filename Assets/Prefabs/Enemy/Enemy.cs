using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public List<Transform> Path;
    public EnemyVision enemyVision;
    
    [SerializeField] private UnityEvent OnDeath;

    [SerializeField] private int Health = 100;


    public int TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0)
            OnDeath.Invoke();
        return Health;
    }
}

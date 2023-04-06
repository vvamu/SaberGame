using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : Character
{
    public List<Transform> Path;
    public EnemyVision enemyVision;
    public float TakeDamage(float damage)
    {
        if (Health < 0)
            OnDeath.Invoke();
        Health -= damage;
        return Health;
    }
}

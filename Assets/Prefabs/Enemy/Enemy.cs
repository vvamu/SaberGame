using Assets.Scripts.Weapon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public List<Transform> Path;
    public EnemyVision EnemyVision;
    public EnemyWeapon Weapon;
    
    [SerializeField] private UnityEvent OnDeath;

    [SerializeField] private int Health = 100;

    [Header("Movement")]
    public float WalkSpeed;
    public float SprintSpeed;

    public int TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0)
            OnDeath.Invoke();
        return Health;
    }
}
using Assets.Scripts;
using Assets.Scripts.Weapon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : Character
{
    public BaseWeapon Weapon;
    [SerializeField] protected UnityEvent _onHit;
    public override float TakeDamage(float damage)
    {
        _onHit.Invoke();
        return base.TakeDamage(damage);
    }
}
using Assets.Scripts;
using Assets.Scripts.Weapon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : Character
{
    public BaseWeapon Weapon;
    public override float TakeDamage(float damage)
    {
        EventBus.onHit?.Invoke();
        return base.TakeDamage(damage);
    }
}
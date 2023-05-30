using Assets.Scripts;
using Assets.Scripts.Weapon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : Character
{
    public List<Transform> Path;
    public EnemyVision EnemyVision;
    public BaseWeapon Weapon;

    [Header("Movement")]
    public float WalkSpeed;
    public float SprintSpeed;    
}
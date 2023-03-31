using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [Range(0, 360)]
    [SerializeField] 
    private float Angle;

    [SerializeField] private float Range;

    [SerializeField] private LayerMask targetMask;
    [SerializeField] private LayerMask obstacleMask;

    public GameObject? SearchForTarget()
    {
        Collider[] colliderInRange = Physics.OverlapSphere(transform.position, Range, targetMask);

        if (colliderInRange.Length == 0) return null;

        Transform target = colliderInRange[0].transform;
        Vector3 directionToTarget = (target.position - transform.position).normalized;

        if(Vector3.Angle(transform.forward, directionToTarget) >= Angle / 2) return null;
        
        if(Physics.Raycast(transform.position, directionToTarget, Range, obstacleMask)) return null;

        return colliderInRange[0].gameObject;
    }
}

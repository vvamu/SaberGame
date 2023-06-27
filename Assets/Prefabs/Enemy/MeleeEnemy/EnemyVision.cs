using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [Range(0, 360)]
    public float Angle;

    public float Range;
    public float RangeApriori;

    [SerializeField] private LayerMask targetMask;
    [SerializeField] private LayerMask obstacleMask;

    private Collider[] _collidersBuffer = new Collider[2];

    public GameObject? SearchForTarget()
    {
        int count = Physics.OverlapSphereNonAlloc(transform.position, RangeApriori, _collidersBuffer, targetMask);
        if(count > 0) return _collidersBuffer[0].gameObject;

        count = Physics.OverlapSphereNonAlloc(transform.position, Range, _collidersBuffer, targetMask);

        if (count == 0) return null;

        Transform target = _collidersBuffer[0].transform;
        Vector3 directionToTarget = (target.position - transform.position).normalized;

        if(Vector3.Angle(transform.forward, directionToTarget) >= Angle / 2) return null;
        
        if(Physics.Raycast(transform.position, directionToTarget, Range, obstacleMask)) return null;

        return _collidersBuffer[0].gameObject;
    }
}

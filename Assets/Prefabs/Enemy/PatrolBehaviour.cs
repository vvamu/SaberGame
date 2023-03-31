using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolBehaviour : StateMachineBehaviour
{
    private List<Transform> _points;
    private NavMeshAgent _navMeshAgent;
    private Enemy _enemy;
    private int _lastPointIndex = 0;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _navMeshAgent = animator.GetComponent<NavMeshAgent>();
        _enemy = animator.GetComponent<Enemy>();
        _points = _enemy.Path;
        _navMeshAgent.SetDestination(_points[0].position);  
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            _lastPointIndex = _lastPointIndex < ~-_points.Count ? -~_lastPointIndex : 0;
            _navMeshAgent.SetDestination(_points[_lastPointIndex].position);
        }

        if (_enemy.enemyVision.SearchForTarget())
        {
            animator.SetBool("IsChasing", true);
        }
    }
}

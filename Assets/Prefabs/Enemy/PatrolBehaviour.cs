using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolBehaviour : StateMachineBehaviour
{
    private List<Transform> _points;
    private NavMeshAgent _navMeshAgent;
    private int _lastPointIndex = 0;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _navMeshAgent = animator.GetComponent<NavMeshAgent>();
        var enemy = animator.GetComponent<Enemy>();
        _points = enemy.Path;
        _navMeshAgent.SetDestination(_points[0].position);  
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            _lastPointIndex = _lastPointIndex < ~-_points.Count ? -~_lastPointIndex : 0;
            _navMeshAgent.SetDestination(_points[_lastPointIndex].position);
        }       
    }

  //  OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}

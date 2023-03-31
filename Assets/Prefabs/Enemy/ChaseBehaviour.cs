using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseBehaviour : StateMachineBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Enemy _enemy;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _navMeshAgent = animator.GetComponent<NavMeshAgent>();
        _enemy = animator.GetComponent<Enemy>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var target = _enemy.enemyVision.SearchForTarget();

        if (target == null)
        {
            animator.SetBool("IsChasing", false);
        }
        else
        {
            _navMeshAgent.SetDestination(target.transform.position);
        }
    }
}

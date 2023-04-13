using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "FSM/Actions/Patrol")]
public class PatrolAction : FSMAction
{
    private int _lastPointIndex = 0;

    public override void Execute(BaseStateMachine stateMachine)
    {
        var navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
        var points = stateMachine.GetComponent<Enemy>().Path;

        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            _lastPointIndex = _lastPointIndex < ~-points.Count ? -~_lastPointIndex : 0;
            navMeshAgent.SetDestination(points[_lastPointIndex].position);
        }
    }
}

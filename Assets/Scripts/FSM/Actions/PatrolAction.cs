using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "FSM/Actions/Patrol")]
public class PatrolAction : FSMAction
{
    public override void Execute(BaseStateMachine stateMachine)
    {
        var navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
        var points = stateMachine.GetComponent<Enemy>().Path;

        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            int _lastPointIndex = (int)stateMachine.Variables["_lastPointIndex"];
            _lastPointIndex = _lastPointIndex < ~-points.Count ? -~_lastPointIndex : 0;
            navMeshAgent.SetDestination(points[_lastPointIndex].position);
            stateMachine.Variables["_lastPointIndex"] = _lastPointIndex;
        }
    }
}

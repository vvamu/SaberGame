using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "FSM/Decision/IsPositionReached")]
public class IsPositionReached : Decision
{    
    public override bool Decide(BaseStateMachine state)
    {
        var navMeshAgent = state.GetComponent<NavMeshAgent>();
        return (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance);
    }       
}

using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "FSM/Actions/Chase")]
public class ChaseAction : FSMAction
{
    public override void Execute(BaseStateMachine stateMachine)
    {
        var navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
        var enemyVision = stateMachine.GetComponent<Enemy>().EnemyVision;

        var player = enemyVision.SearchForTarget();
        if(player)
            navMeshAgent.SetDestination(player.transform.position);
    }
}

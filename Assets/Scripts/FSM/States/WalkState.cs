using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "FSM/States/WalkState")]
public class WalkState : State
{
    public override void OnStateEnter(BaseStateMachine stateMachine)
    {
        var enemy = stateMachine.GetComponent<Enemy>();
        var agent = stateMachine.GetComponent<NavMeshAgent>();

        agent.speed = enemy.WalkSpeed;

        base.OnStateEnter(stateMachine);
    }
}
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "FSM/States/SprintState")]
public class SprintState : State
{
    public override void OnStateEnter(BaseStateMachine stateMachine)
    {
        var enemy = stateMachine.GetComponent<Enemy>(); 
        var agent = stateMachine.GetComponent<NavMeshAgent>();

        agent.speed = enemy.SprintSpeed;
        
        base.OnStateEnter(stateMachine);
    }
}

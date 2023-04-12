using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "FSM/AttackState")]
public class AttackState : StateWithInitTime
{
    public override void OnStateEnter(BaseStateMachine stateMachine)
    {
        var animator = stateMachine.GetComponent<Animator>();
        var nav = stateMachine.GetComponent<NavMeshAgent>();

        nav.ResetPath();
        animator.SetTrigger("Attack");
        Debug.Log("Attack");
        base.OnStateEnter(stateMachine);
    }
}

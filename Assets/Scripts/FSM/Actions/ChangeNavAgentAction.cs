using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "FSM/Actions/ChangeNavAgent")]
public class ChangeNavAgentAction : FSMAction
{
    [SerializeField] private bool Active;
    public override void Execute(BaseStateMachine stateMachine)
    {
        stateMachine.GetComponent<NavMeshAgent>().isStopped = !Active;
    }
}

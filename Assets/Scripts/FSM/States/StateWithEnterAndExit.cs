using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/States/StateWithEnterAndExit")]
public class StateWithEnterAndExit : State
{
    public List<FSMAction> OnEnter = new List<FSMAction>();
    public List<FSMAction> OnExit = new List<FSMAction>();

    public override void OnStateEnter(BaseStateMachine stateMachine)
    {
        foreach (var action in OnEnter)
            action.Execute(stateMachine);
    }

    public override void OnStateExit(BaseStateMachine stateMachine)
    {
        foreach (var action in OnExit)
            action.Execute(stateMachine);
    }
}

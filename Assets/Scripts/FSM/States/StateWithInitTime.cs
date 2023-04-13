using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/StateWithInitTime")]
public class StateWithInitTime : State
{
    public override void OnStateEnter(BaseStateMachine stateMachine)
    {
        stateMachine.Variables[nameof(TimeOutDecision._startTime)] = Time.time;
    }
}

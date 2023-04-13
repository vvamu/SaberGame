using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Actions/ResetPatrolPath")]
public class ResetPatrolPathAction : FSMAction
{
    public override void Execute(BaseStateMachine stateMachine)
    {
        stateMachine.Variables["_lastPointIndex"] = 0;
    }
}

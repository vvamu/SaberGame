using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Actions/InitTime")]
public class InitTimeAction : FSMAction
{
    public override void Execute(BaseStateMachine stateMachine)
    {
        stateMachine.Variables[nameof(TimeOutDecision._startTime)] = Time.time;
    }
}

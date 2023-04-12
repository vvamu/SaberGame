using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Decision/TimeOutDecision")]
public class TimeOutDecision : Decision
{
    [SerializeField] private float Timeout;

    public readonly float _startTime;

    public override bool Decide(BaseStateMachine state)
    {
        return Time.time - (float)state.Variables[nameof(_startTime)] > Timeout;
    }
}

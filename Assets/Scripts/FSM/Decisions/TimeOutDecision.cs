using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOutDecision : Decision
{
    [SerializeField] private float Timeout;

    private float _startTime = 0f;

    public override bool Decide(BaseStateMachine state)
    {
        return Time.time - _startTime > Timeout;
    }

    public override void Reset()
    {
        _startTime = Time.time;
    }
}

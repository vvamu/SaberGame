using UnityEngine;

public abstract class BaseState : ScriptableObject
{
    public virtual void OnStateEnter(BaseStateMachine stateMachine) { }
    public abstract void Execute(BaseStateMachine machine);
    public virtual void OnStateExit(BaseStateMachine stateMachine) { }
}

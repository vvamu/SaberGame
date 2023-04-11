using UnityEngine;

public abstract class BaseState : ScriptableObject
{
    public abstract void Execute(BaseStateMachine machine);
}

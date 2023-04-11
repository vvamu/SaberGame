using UnityEngine;

[CreateAssetMenu(menuName = "FSM/SingleActionState")]
public class SingleActionState : BaseState
{
    [SerializeField] private FSMAction Action;
    [SerializeField] private Transition Transition;

    public override void Execute(BaseStateMachine machine)
    {
        Action.Execute(machine);
        Transition.Execute(machine);
    }
}

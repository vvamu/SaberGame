using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Actions/LookAround")]
public class LookAroundAction : FSMAction
{
    public override void Execute(BaseStateMachine stateMachine)
    {
        stateMachine.transform.rotation = Quaternion.Euler(stateMachine.transform.rotation.eulerAngles + new Vector3(0.02f * Time.deltaTime, 0));
    }   
}

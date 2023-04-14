using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "FSM/Actions/LookAtPlayer")]
public class LookAtPlayerAction : FSMAction
{
    public override void Execute(BaseStateMachine stateMachine)
    {
        var navMesh = stateMachine.GetComponent<NavMeshAgent>();

        var turnTowardNavSteeringTarget = navMesh.steeringTarget;

        Vector3 direction = (turnTowardNavSteeringTarget - stateMachine.transform.position).normalized;
        if (direction.x != 0 || direction.z != 0)
        {
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            stateMachine.transform.rotation = Quaternion.Slerp(stateMachine.transform.rotation, lookRotation, Time.deltaTime * 10);
        }
    }
}

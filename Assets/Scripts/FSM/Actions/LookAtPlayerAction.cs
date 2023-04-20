using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "FSM/Actions/LookAtPlayer")]
public class LookAtPlayerAction : FSMAction
{
    public override void Execute(BaseStateMachine stateMachine)
    {
        var vision = stateMachine.GetComponent<Enemy>().EnemyVision;

        if (vision.SearchForTarget() == null) return;

        var turnTowardNavSteeringTarget = vision.SearchForTarget().transform.position;

        Vector3 direction = (turnTowardNavSteeringTarget - stateMachine.transform.position).normalized;
        if (direction.x != 0 || direction.z != 0)
        {
            //Debug.Log("sad");
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            stateMachine.transform.rotation = Quaternion.Slerp(stateMachine.transform.rotation, lookRotation, Time.deltaTime * 10);
        }
    }
}

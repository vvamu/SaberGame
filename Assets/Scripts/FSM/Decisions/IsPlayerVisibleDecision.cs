using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Decision/IsPlayerVisibleDecision")]
public class IsPlayerVisibleDecision : Decision
{
    public override bool Decide(BaseStateMachine stateMachine)
    {
        var enemyInLineOfSight = stateMachine.GetComponent<Enemy>();
        return enemyInLineOfSight.EnemyVision.SearchForTarget() != null;
    }
}

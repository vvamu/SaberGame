using UnityEngine;

[CreateAssetMenu(menuName = "FSM/Decision/IsNearWithPlayer")]
public class IsNearWithPlayer : Decision
{
    [Min(0)]
    public float delta;
    public override bool Decide(BaseStateMachine state)
    {
        var enemyInLineOfSight = state.GetComponent<Enemy>();
        var player = enemyInLineOfSight.EnemyVision.SearchForTarget();
        if (player)
        {
            float distance = (player.transform.position - state.transform.position).magnitude;
            return distance < delta;
        }else { return false; }
    }
}

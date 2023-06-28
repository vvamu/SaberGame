using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "FSM/AttackState")]
public class AttackState : StateWithInitTime
{
    public override void OnStateEnter(BaseStateMachine stateMachine)
    {
        var nav = stateMachine.GetComponent<NavMeshAgent>();
        var enemy = stateMachine.GetComponent<Enemy>();
        var weapon = enemy.Weapon;
        var player = enemy.EnemyVision.SearchForTarget();

        nav.ResetPath();

        var direction = player.transform.position - enemy.transform.position;
        weapon.Aim.SetShootPositionAndDirection(enemy.transform.position, direction);
        weapon.Aim.AimendAttack();
        base.OnStateEnter(stateMachine);
    }
}

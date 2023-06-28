using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "FSM/Actions/Attack")]
public class AttackAction : FSMAction
{
    public override void Execute(BaseStateMachine stateMachine)
    {
        var enemy = stateMachine.GetComponent<Enemy>();
        var weapon = enemy.Weapon;
        var player = enemy.EnemyVision.SearchForTarget();

        Debug.Log("Attack");

        var direction = player.transform.position - enemy.transform.position;
        weapon.Aim.SetShootPositionAndDirection(enemy.transform.position, direction);
        weapon.Aim.AimendAttack();
        //if (player)
        //    enemy.Weapon.Shoot(player.transform.position);
        //TODO
    }
}
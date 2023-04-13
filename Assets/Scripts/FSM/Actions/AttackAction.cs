using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "FSM/Actions/Attack")]
public class AttackAction : FSMAction
{
    public override void Execute(BaseStateMachine stateMachine)
    {
        var animator = stateMachine.GetComponent<Animator>();
        var enemy = stateMachine.GetComponent<Enemy>();
        var player = enemy.EnemyVision.SearchForTarget();

        animator.SetTrigger("Attack");
        Debug.Log("Attack");
        if (player)
            enemy.Weapon.Shoot(player.transform.position);
    }
}
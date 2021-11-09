using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState1 : StateMachineBehaviour
{
    Transform enemyTransform;
    Enemy enemy;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<Enemy>();
        enemyTransform = animator.GetComponent<Transform>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(Enemy.player.transform.position, enemyTransform.position) < 1f)
        {
            animator.SetTrigger("Attack");
            Enemy.player.ReceiveDamage(enemy.AttackValue);
        }
        else
        {
            enemyTransform.position = Vector2.MoveTowards(enemyTransform.position, Enemy.player.transform.position, Time.deltaTime * enemy.speed);
        }
        enemy.DirectionEnemy(Enemy.player.transform.position.x, enemyTransform.position.x);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    Transform enemyTransform;
    Enemy enemy;

    //상태에 진입 할때
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<Enemy>();
        enemyTransform = animator.GetComponent<Transform>();
    }

    //상태가 진행중일때
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //몬스터와 플레이어 사이의 거리가 4이하면 
        if (Vector2.Distance(enemyTransform.position, Enemy.player.transform.position) <= 4f)
            animator.SetBool("isWalk", true);
    }

    //상태가 끝날때
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}

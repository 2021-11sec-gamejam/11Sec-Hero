using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    Transform enemyTransform;
    Enemy enemy;

    //���¿� ���� �Ҷ�
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<Enemy>();
        enemyTransform = animator.GetComponent<Transform>();
    }

    //���°� �������϶�
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //���Ϳ� �÷��̾� ������ �Ÿ��� 4���ϸ� 
        if (Vector2.Distance(enemyTransform.position, Enemy.player.transform.position) <= 4f)
            animator.SetBool("isWalk", true);
    }

    //���°� ������
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}

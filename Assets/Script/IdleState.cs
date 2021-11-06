using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    Transform enemyTransform;
    Enemy enemy;    

    //���¿� ���� �Ҷ�
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<Enemy>();
        enemyTransform = animator.GetComponent<Transform>();
    }

    //���°� �������϶�
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //���Ϳ� �÷��̾� ������ �Ÿ��� 4���ϸ� 
        if (Vector2.Distance(enemyTransform.position, enemy.player.position) <= 4f)
            animator.SetBool("isWalk", true);
    }

    //���°� ������
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}

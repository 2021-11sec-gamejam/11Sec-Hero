using System.Collections;
using System.Collections.Generic;
using Player;
using Singleton;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static PlayerModel player;  
    public float speed;
    private Animator animator;
    private SpriteRenderer enemySprite;    
    
    public float HP;
    public float AttackValue;

    private void Start()
    {
        player ??= GameManager.Instance.player;
        animator = GetComponent<Animator>();
        speed = 3f;
    }

    public void DirectionEnemy(float target, float baseobj)
    {
        if (target < baseobj)
        {
            //왼쪽
            animator.SetFloat("Direction", -1f);                   
            transform.localScale = new Vector3(-3f, 3f, 1f);
        }
        else 
        {
            //왼쪽
            animator.SetFloat("Direction", 1f);            
            transform.localScale = new Vector3(3f, 3f, 1f);            
        }
    }

    public virtual void ReceiveDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            // Die method... TODO.
            animator.SetBool("isDie", true);
        }
    }
}

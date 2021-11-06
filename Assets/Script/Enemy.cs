using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;    
    public float speed;
    private Animator animator;
    private SpriteRenderer enemySprite;    

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        speed = 3f;
      
    }

    public void DirectionEnemy(float target, float baseobj)
    {
        if (target < baseobj)
        {
            //¿ÞÂÊ
            animator.SetFloat("Direction", -1f);                   
            transform.localScale = new Vector3(-3f, 3f, 1f);
        }
        else 
        {
            //¿ÞÂÊ
            animator.SetFloat("Direction", 1f);            
            transform.localScale = new Vector3(3f, 3f, 1f);            
        }
    }    

    
}

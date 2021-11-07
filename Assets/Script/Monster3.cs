using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster3 : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        HP = 40f;
        AttackValue = 2f;
        speed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

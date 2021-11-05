using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public PlayerModel model;
    public float speed = 1f;

    private void Update()
    {
        switch (model.state)
        {
            case PlayerModel.PlayerState.Idle:
                var input = GetMovingInput();
                if (input != Vector2.zero)
                {
                    transform.Translate(input * (Time.deltaTime * speed));
                    model.state = PlayerModel.PlayerState.Walk;
                }
                break;
            case PlayerModel.PlayerState.Walk:
                input = GetMovingInput();
                if (input != Vector2.zero)
                {
                    transform.Translate(input * (Time.deltaTime * speed));
                }
                else
                {
                    model.state = PlayerModel.PlayerState.Idle;
                }
                break;
            case PlayerModel.PlayerState.Death:
                break;
        }
    }

    private static Vector2 GetMovingInput()
    {
        var x = 0f;
        x += Input.GetKey(KeyCode.A) ? -1 : 0;
        x += Input.GetKey(KeyCode.D) ? 1 : 0;
        var y = 0f;
        y += Input.GetKey(KeyCode.W) ? 1 : 0;
        y += Input.GetKey(KeyCode.S) ? -1 : 0;
        return new Vector2(x, y);
    }

    private void GetAttackInput()
    {
        //Input.GetMouseButton(1) ? model. 
    }
}
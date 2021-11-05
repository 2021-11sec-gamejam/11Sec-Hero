using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 1f;

    private void Update()
    {
        transform.Translate(GetInput() * (Time.deltaTime * speed));
    }

    private static Vector2 GetInput()
    {
        var x = 0f;
        x += Input.GetKey(KeyCode.A) ? -1 : 0;
        x += Input.GetKey(KeyCode.D) ? 1 : 0;
        var y = 0f;
        y += Input.GetKey(KeyCode.W) ? 1 : 0;
        y += Input.GetKey(KeyCode.S) ? -1 : 0;
        return new Vector2(x, y);
    }
}

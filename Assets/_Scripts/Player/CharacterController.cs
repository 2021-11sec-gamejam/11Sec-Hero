using Player;
using UnityEngine;

namespace Player
{
    public class CharacterController : MonoBehaviour
    {
        public PlayerModel model;
        public float speed = 1f;

        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            switch (model.state)
            {
                case PlayerModel.PlayerState.Idle:
                    var input = GetMovingInput();
                    if (input != Vector2.zero)
                    {
                        transform.Translate(input * (Time.deltaTime * speed));
                        if (input.x > 0)
                        {
                            _spriteRenderer.flipX = true;
                        }
                        model.state = PlayerModel.PlayerState.Walk;
                    }
                    GetAttackInput();
                    break;
                case PlayerModel.PlayerState.Walk:
                    input = GetMovingInput();
                    if (input != Vector2.zero)
                    {
                        transform.Translate(input * (Time.deltaTime * speed));
                        if (input.x != 0)
                        {
                            _spriteRenderer.flipX = input.x > 0;
                        }
                    }
                    else
                    {
                        model.state = PlayerModel.PlayerState.Idle;
                    }
                    GetAttackInput();
                    break;
                case PlayerModel.PlayerState.Attack:
                    if (!model.weapon.model.isAttacking)
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
            if (Input.GetMouseButtonDown(1))
            {
                model.weapon.Attack();
            }
        }
    }
}
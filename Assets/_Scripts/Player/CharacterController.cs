using Player;
using UnityEngine;
using Weapon;

namespace Player
{
    public class CharacterController : MonoBehaviour
    {
        public PlayerModel model;
        public float speed = 1f;

        private SpriteRenderer _spriteRenderer;
        private Vector2 _deltaPosition;

        public float MovedDistance { get; set; } = 0f;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _deltaPosition = transform.position;
        }

        private void Update()
        {
            MovedDistance += Vector2.Distance(_deltaPosition, transform.position);
            _deltaPosition = transform.position;
            
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
                    GetPickupInput();
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
                    GetPickupInput();
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

        private void GetPickupInput()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Physics2D.OverlapCircle(transform.position, 1.5f).TryGetComponent(out ItemObject item);
                if (item)
                {
                    model.ChangeWeapon(item.model);
                    Destroy(item.gameObject);
                }
            }
        }
    }
}
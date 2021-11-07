using System;
using Factory;
using Singleton;
using UnityEngine;

namespace Player
{
    using Weapon;
    
    public class PlayerModel : MonoBehaviour
    {
        public enum PlayerState : int
        {
            Idle,
            Walk,
            Attack,
            Death
        }

        public PlayerState state = PlayerState.Idle;

        public float RemainTime
        {
            get => _remainTime;
            set => _remainTime = value + _remainTime > 11f ? 11f : value;
        }

        public Weapon weapon;
        public Animator animator;

        private float _remainTime;
        private static readonly int Die = Animator.StringToHash("Die");

        public void Awake()
        {
            ChangeWeapon(WeaponFactory.Instance.GetBasicWeapon());
            RemainTime = 11f;
        }

        private void Update()
        {
            _remainTime -= Time.deltaTime;
            if (_remainTime < 0f)
            {
                _remainTime = 0f;
                if (state != PlayerState.Death)
                {
                    state = PlayerState.Death;
                    animator.SetTrigger(Die);
                    GameManager.Instance.GameOver();
                }
            }
        }

        public void ChangeWeapon(Weapon.WeaponModel model)
        {
            Destroy(weapon);
            weapon = model.type switch
            {
                Weapon.WeaponType.Sword => gameObject.AddComponent<Sword>(),
                Weapon.WeaponType.Axe => gameObject.AddComponent<Axe>(),
                Weapon.WeaponType.Blunt => gameObject.AddComponent<Blunt>(),
                _ => weapon
            };
            weapon.model = model;
            animator.runtimeAnimatorController =
                Resources.Load<AnimatorOverrideController>($"Animator/{model.weaponName}");
        }
    }
}
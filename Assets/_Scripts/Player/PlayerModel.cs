using System;
using System.Collections;
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
            set => _remainTime = value > 11f ? 11f : value;
        }

        public Weapon weapon;
        public Animator animator;

        private float _remainTime;
        private static readonly int Die = Animator.StringToHash("Die");
        public bool isInvincibility;

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

            GameManager.Instance.timeText.text = $"남은 시간 : {_remainTime:F1}초";
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

        public void ReceiveDamage(float damage)
        {
            if (!isInvincibility)
            {
                _remainTime -= damage;
                StartCoroutine(ResetInvincibility());
            }
        }

        private IEnumerator ResetInvincibility()
        {
            isInvincibility = true;
            yield return new WaitForSeconds(1.5f);
            isInvincibility = false;
        }
    }
}
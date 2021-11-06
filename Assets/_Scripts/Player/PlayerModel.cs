using System;
using Factory;
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

        private float _remainTime;

        public void Awake()
        {
            var model = WeaponFactory.Instance.GetBasicWeapon();
            weapon = gameObject.AddComponent<Sword>();
            weapon.model = model;
        }

        private void Update()
        {
            _remainTime -= Time.deltaTime;
            if (_remainTime < 0f)
            {
                _remainTime = 0f;
            }
        }
    }
}
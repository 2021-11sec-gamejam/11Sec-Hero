using System;
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
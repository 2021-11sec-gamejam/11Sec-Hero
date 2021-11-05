using UnityEngine;

namespace Player
{
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

        private float _remainTime;
    }
}
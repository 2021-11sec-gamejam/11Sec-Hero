using System;
using Player;
using UnityEngine;

namespace Singleton
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] public GameObject playerSample;
        
        public PlayerModel player;

        protected void Start()
        {
            player ??= Instantiate(playerSample, Vector3.zero, Quaternion.identity).GetComponent<PlayerModel>();
        }
    }
}
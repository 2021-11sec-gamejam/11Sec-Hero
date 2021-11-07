﻿using System;
using Player;
using UnityEngine;

namespace Singleton
{
    public class GameManager : Singleton<GameManager>
    {
        public PlayerModel player;

        protected override void OnAwake()
        {
            base.OnAwake();
            player ??= Instantiate(Resources.Load<GameObject>("Player"), Vector3.zero, Quaternion.identity).GetComponent<PlayerModel>();
        }

        public void GameOver()
        {
            //Time.timeScale = 0;
            Debug.Log("으앙쥬금");
        }
    }
}
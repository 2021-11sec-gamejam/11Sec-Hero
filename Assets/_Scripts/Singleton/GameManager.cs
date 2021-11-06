using Player;
using UnityEngine;

namespace Singleton
{
    public class GameManager : Singleton<GameManager>
    {
        public PlayerModel player;
    }
}
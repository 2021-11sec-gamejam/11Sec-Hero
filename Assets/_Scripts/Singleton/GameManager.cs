using System;
using DG.Tweening;
using Factory;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Weapon;
using CharacterController = Player.CharacterController;
using Random = UnityEngine.Random;

namespace Singleton
{
    public class GameManager : Singleton<GameManager>
    {
        public PlayerModel player;

        private bool _isPaused;
        private float _screenHeight;
        private static readonly int[] RarityWeights = {3, 4, 5};
        private CharacterController _characterController;
        private int _canGetWeaponRarity = 0;
        public Camera MainCamera;
        public TMP_Text timeText;
        public TMP_Text gameOverText;

        protected override void OnAwake()
        {
            base.OnAwake();
            player ??= Instantiate(Resources.Load<GameObject>("Player"), Vector3.zero, Quaternion.identity).GetComponent<PlayerModel>();
            MainCamera = Camera.main;
            _characterController = player.GetComponent<CharacterController>();
            _screenHeight = Screen.currentResolution.height;
        }

        protected void LateUpdate()
        {
            if (_characterController.MovedDistance > _screenHeight * RarityWeights[_canGetWeaponRarity])
            {
                if (Random.Range(0f, 1f) > .7f)
                {
                    var model = WeaponFactory.Instance.GetRandomWeaponByRarity(_canGetWeaponRarity);
                    float spawnY = Random.Range
                        (MainCamera.ScreenToWorldPoint(new Vector2(0, 0)).y, MainCamera.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
                    float spawnX = Random.Range
                        (MainCamera.ScreenToWorldPoint(new Vector2(0, 0)).x, MainCamera.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
 
                    var spawnPosition = new Vector2(spawnX, spawnY);
                    Instantiate(Resources.Load<ItemObject>($"Item/{model.weaponName}"),spawnPosition, Quaternion.identity);
                }

                _characterController.MovedDistance = 0f;
                _canGetWeaponRarity = _canGetWeaponRarity < 2 ? _canGetWeaponRarity + 1 : _canGetWeaponRarity;
            }
            
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = _isPaused ? 1 : 0;
                _isPaused = !_isPaused;
            }

            if (Input.GetKeyDown(KeyCode.R) && player.RemainTime <= 0f)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }

        public void GameOver()
        {
            //Time.timeScale = 0;
            Debug.Log("으앙쥬금");
            gameOverText.gameObject.SetActive(true);
            gameOverText.DOFade(0f, 0f);
            gameOverText.DOFade(1f, 1f);
        }
    }
}
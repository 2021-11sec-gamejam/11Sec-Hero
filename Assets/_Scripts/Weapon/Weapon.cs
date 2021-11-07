using System;
using System.Collections;
using DG.Tweening;
using Singleton;
using UnityEngine;

namespace Weapon
{
    public abstract class Weapon : MonoBehaviour
    {
        public enum WeaponType
        {
            Sword = 0,
            Axe,
            Blunt
        }
        
        [Serializable]
        public struct WeaponModel
        {
            public WeaponType type;
            public int rarity;
            public string weaponName;
            public float coolDown;
            public float damageValue;
            public bool isAttacking;
        }
        
        public WeaponModel model;
        protected Vector3 _movePosition;

        public virtual bool Attack()
        {
            if (!model.isAttacking)
            {
                model.isAttacking = true;
                GameManager.Instance.player.animator.SetBool(IsAttacking, true);
                var mousePos = MainCam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                _movePosition = transform.position + mousePos.normalized * (model.rarity + 1) * 3f;
                _movePosition.z = transform.position.z;
                GameManager.Instance.player.GetComponent<SpriteRenderer>().flipX = transform.position.x < _movePosition.x;
                DOTween.Sequence()
                    .Append(transform
                        .DOMove(_movePosition, model.coolDown / 2f)
                        .SetEase(Ease.InCirc))
                    .InsertCallback(model.coolDown, () =>
                    {
                        model.isAttacking = false;
                        GameManager.Instance.player.animator.SetBool(IsAttacking, false);
                    });

                return true; // 공격 성공
            }

            return false; // 공격 실패
        }

        protected static Camera MainCam;
        private static readonly int IsAttacking = Animator.StringToHash("isAttacking");

        protected virtual void Awake()
        {
            MainCam ??= Camera.main;
        }

        protected virtual void Update()
        {
            if (!model.isAttacking)
            {
                
            }
        }
    }
}
using System;
using System.Collections;
using DG.Tweening;
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
        
        protected Sequence _attackSequence;

        public virtual bool Attack()
        {
            if (!model.isAttacking)
            {
                model.isAttacking = true;
                var mousePos = MainCam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                var movePos = transform.position + mousePos.normalized * (model.rarity + 1) * 3f;
                movePos.z = transform.position.z;
                _attackSequence = DOTween.Sequence()
                    .Append(transform
                        .DOMove(movePos, model.coolDown / 2f)
                        .SetEase(Ease.InCirc))
                    .InsertCallback(model.coolDown, () => model.isAttacking = false);

                return true; // 공격 성공
            }

            return false; // 공격 실패
        }

        protected static Camera MainCam; 

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
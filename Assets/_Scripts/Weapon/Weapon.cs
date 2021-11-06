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
            public float dashWeight;
            public float damageValue;
            public bool isAttacking;
        }
        
        public WeaponModel model;
        
        protected Sequence _attackSequence;

        public abstract void Attack();

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
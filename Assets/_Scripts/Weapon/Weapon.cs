using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Weapon
{
    public abstract class Weapon : MonoBehaviour
    {
        [Serializable]
        public struct WeaponModel
        {
            public int rarity;
            public string weaponName;
            public float coolDown;
            public float dashWeight;
            public bool isAttacking;
        }
        
        public WeaponModel model;
        
        protected Sequence _attackSequence;

        public abstract void Attack();

        protected virtual void Awake()
        {
            
        }

        protected virtual void Update()
        {
            if (!model.isAttacking)
            {
                
            }
        }
    }
}
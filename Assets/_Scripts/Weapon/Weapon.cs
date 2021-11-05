using System.Collections;
using UnityEngine;

namespace Weapon
{
    public abstract class Weapon : MonoBehaviour
    {
        public int rarity;
        public string weaponName;
        protected bool _isAttacking;
        protected float _coolDown;

        public abstract void Attack(Vector2 mousePosition);
        protected abstract IEnumerator CoolDown();
    }
}
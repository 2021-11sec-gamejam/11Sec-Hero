using System;
using System.Collections;
using Factory;
using UnityEngine;

namespace Weapon
{
    [RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
    public class ItemObject : MonoBehaviour
    {
        public Weapon.WeaponModel model;
        [SerializeField] private string weaponName;

        public void Awake()
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
            var rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.sleepMode = RigidbodySleepMode2D.NeverSleep;
            rigidbody.bodyType = RigidbodyType2D.Static;

            if (!string.IsNullOrWhiteSpace(weaponName))
            {
                model = WeaponFactory.Instance.GetWeaponByName(weaponName);
            }
        }
    }
}
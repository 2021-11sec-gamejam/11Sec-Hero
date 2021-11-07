using System;
using System.Collections.Generic;
using System.Linq;
using Module;
using Singleton;
using UnityEngine;

namespace Factory
{
    using Weapon;

    public class WeaponFactory : Singleton<WeaponFactory>
    {
        private const string BasicWeapon = "보급형 검";
        private List<Weapon.WeaponModel> _weapons;
        private const string CsvPath = "Weapon";
        
        protected override void Awake()
        {
            base.Awake();
            var text = Resources.Load<TextAsset>(CsvPath);
            _weapons = CsvParser.GetWeapons(text.text);
        }

        public Weapon.WeaponModel GetBasicWeapon()
        {
            return _weapons.First(model => model.weaponName.Equals(BasicWeapon));
        }

        public Weapon.WeaponModel GetWeaponByName(string weaponName)
        {
            return _weapons.First(model => model.weaponName.Equals(weaponName));
        }

        public Weapon.WeaponModel GetRandomWeaponByRarity(int rarity)
        {
            return _weapons.Where(model => model.rarity == rarity).OrderBy(_ => new Guid()).First();
        }
    }
}
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
            return _weapons.First(model => model.weaponName.Equals("Entry_Sword"));
        }
    }
}
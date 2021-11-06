using System;
using System.Collections.Generic;
using System.Linq;

namespace Module
{
    using Weapon;
    public static class CsvParser
    {
        public static List<Weapon.WeaponModel> GetWeapons(string csv)
        {
            var strings = csv.Split('\n');
            var list = new List<Weapon.WeaponModel>();
            foreach (var line in strings.Skip(1))
            {
                var elements = line.Split(',');
                var model = new Weapon.WeaponModel();
                for (int i = 0; i < elements.Length; i++)
                {
                    if (i == 1)
                    {
                        continue;
                    }
                    
                    switch (i)
                    {
                        case 0:
                            model.type = (Weapon.WeaponType) int.Parse(elements[i]);
                            break;
                        case 2:
                            int.TryParse(elements[i], out model.rarity);
                            break;
                        case 3:
                            model.weaponName = elements[i];
                            break;
                        case 4:
                            float.TryParse(elements[i], out model.damageValue);
                            break;
                        case 5:
                            float.TryParse(elements[i], out model.coolDown);
                            break;
                    }
                }
                list.Add(model);
            }

            return list;
        }
    }
}
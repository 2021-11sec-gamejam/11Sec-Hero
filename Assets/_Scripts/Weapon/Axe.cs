using System.Linq;
using UnityEngine;

namespace Weapon
{
    public class Axe : Weapon
    {
        public override bool Attack()
        {
            var result = base.Attack();
            if (result)
            {
                // ReSharper disable once Unity.PreferNonAllocApi
                Physics2D.OverlapCircleAll(_movePosition, 2f)
                    .Select(col => col.GetComponent<Enemy>())
                    .Where(enemy => enemy != null)
                    .ToList()
                    .ForEach(enemy => enemy.ReceiveDamage(model.damageValue));
            }

            return result;
        }
    }
}
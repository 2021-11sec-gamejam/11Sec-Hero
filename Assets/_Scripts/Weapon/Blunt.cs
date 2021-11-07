using System;
using System.Linq;
using UnityEngine;

namespace Weapon
{
    public class Blunt : Weapon
    {
        public override bool Attack()
        {
            var result = base.Attack();
            if (result)
            {
                // ReSharper disable once Unity.PreferNonAllocApi
                var originPoint = new Vector2(_movePosition.x - transform.position.x, _movePosition.y - transform.position.y); // get origin point to origin by subtracting end from start
                double bearingRadians = Math.Atan2(originPoint.y, originPoint.x); // get bearing in radians
                double bearingDegrees = bearingRadians * (180.0 / Math.PI); // convert to degrees
                bearingDegrees = (bearingDegrees > 0.0 ? bearingDegrees : (360.0 + bearingDegrees)); // correct discontinuity

                Physics2D.OverlapBoxAll(_movePosition, new Vector2(1, 2), (float) bearingDegrees)
                    .Select(col => col.GetComponent<Enemy>())
                    .Where(enemy => enemy != null)
                    .ToList()
                    .ForEach(enemy => enemy.ReceiveDamage(model.damageValue));
            }

            return result;
        }
    }
}
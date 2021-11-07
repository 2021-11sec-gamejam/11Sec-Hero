using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Weapon
{
    public class Sword : Weapon
    {
        public override bool Attack()
        {
            var result = base.Attack();
            if (result)
            {
                
            }

            return result;
        }
    }
}
using System.Collections;
using UnityEngine;

namespace Weapon
{
    public class Sword : Weapon
    {
        public override void Attack(Vector2 mousePosition)
        {
            throw new System.NotImplementedException();
        }

        protected override IEnumerator CoolDown()
        {
            throw new System.NotImplementedException();
        }
    }
}
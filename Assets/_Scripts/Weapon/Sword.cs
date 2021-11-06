using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Weapon
{
    public class Sword : Weapon
    {
        public override void Attack()
        {
            if (!model.isAttacking)
            {
                model.isAttacking = true;
                var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                var movePos = transform.position + mousePos.normalized * model.dashWeight;
                movePos.z = transform.position.z;
                _attackSequence = DOTween.Sequence()
                    .Append(transform
                        .DOMove(movePos, model.coolDown / 2f)
                        .SetEase(Ease.InCirc))
                    .InsertCallback(model.coolDown, () => model.isAttacking = false);
            }
        }
    }
}
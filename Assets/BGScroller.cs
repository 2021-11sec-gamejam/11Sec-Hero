using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Singleton;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    private Transform _playerTransform;
    private Tween _currentTween;

    // Start is called before the first frame update
    private void Awake()
    {
        _playerTransform = GameManager.Instance.player.transform;
    }

    private void Update()
    {
        var distance = Vector2.Distance(transform.position, _playerTransform.position);
        if (distance > 50f && _currentTween == null)
        {
            _currentTween = transform.DOMove(_playerTransform.position, 1f).OnComplete(() => _currentTween = null);
        }
    }
}

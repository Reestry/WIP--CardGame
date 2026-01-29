using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Card : Item
{
    private float _idleDuration = 2;
    private float _rotationAngle = 3f;
    private float _randomDuration;

    private int _randomAngle;



    private Tween _idleTween;
    protected void Start()
    {
        

        _randomDuration = Random.Range(0.1f, 3);
        _idleDuration += _randomDuration;

        _randomAngle = Random.Range(0, 2) * 2 - 1;
        _rotationAngle *= _randomAngle;
        Idle();
    }

    private Vector3 _startRotation = Vector3.zero;

    private void Idle()
    {
        _idleTween = DOTween.Sequence()
            .Append(transform.DOLocalRotate(new Vector3(0, 0, _rotationAngle), _idleDuration))
            .Append(transform.DOLocalRotate(new Vector3(0, 0, -_rotationAngle), _idleDuration))
            .Append(transform.DOLocalRotate(_startRotation, _idleDuration / 2).SetEase(Ease.Linear))
            .SetLoops(-1, LoopType.Restart)
            .SetAutoKill(false);
    }

    protected virtual void MoveTo()
    {
    }

    public void SetPos(Vector2 position)
    {
    }



    public void KillTweens()
    {
        _idleTween?.Kill();
    }
    
}
using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Card : Item
{
    private float _idleDuration = 5;
    private float _randomDuration;

    private int _randomAngle;

    private ItemSway _itemSway;

    protected void Start()
    {
        _itemSway = GetComponentInChildren<ItemSway>();

        _randomDuration = Random.Range(0.1f, 1);
        _idleDuration += _randomDuration;

        _randomAngle = Random.Range(0, 2) * 2 - 1;
        rotationAngle *= _randomAngle;
        Idle();
    }

    private float rotationAngle = 5f;

    private Vector3 _startRotation = Vector3.zero;

    private void Idle()
    {
        DOTween.Sequence()
            .Append(transform.DOLocalRotate(new Vector3(0, 0, rotationAngle), _idleDuration))
            .Append(transform.DOLocalRotate(new Vector3(0, 0, -rotationAngle), _idleDuration))
            .Append(transform.DOLocalRotate(_startRotation, _idleDuration / 2).SetEase(Ease.Linear))
            .SetLoops(-1, LoopType.Restart);
    }

    protected virtual void MoveTo()
    {
    }

    public void SetPos(Vector2 position)
    {
    }

    public void SetSwayAngle(Vector2 angle)
    {
        _itemSway.Sway(angle);
    }

    public void ResetSway()
    {
        _itemSway.ResetSway();
    }
}
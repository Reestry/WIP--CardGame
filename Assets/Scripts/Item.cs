using System;
using DG.Tweening;
using UnityEngine;

public class Item : MonoBehaviour, ITakeable
{
    protected ItemSway _itemSway;

    private Tween _releaseTween;
    private Vector3 _holderPosition;

    private void Start()
    {
        _itemSway = GetComponentInChildren<ItemSway>();
    }

    public virtual void Take()
    {
        _releaseTween?.Kill();
        _holderPosition = transform.position;
    }

    public virtual void Release()
    {
        _itemSway.ResetSway();
        MoveTo(_holderPosition);
    }

    public void MoveTo(Vector3 move)
    {
        transform.DOMove(move, 0.3f).SetAutoKill();
    }

    public void SetSwayAngle(Vector2 angle)
    {
        _itemSway.Sway(angle);
    }
}
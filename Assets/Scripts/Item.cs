using System;
using DG.Tweening;
using UnityEngine;

public class Item : MonoBehaviour, ITakeable
{
    private Tween _releaseTween;
    private Vector3 _startPos;
    
    
    protected ItemSway _itemSway;

    private void Start()
    {
        _itemSway = GetComponentInChildren<ItemSway>();
    }

    public virtual void Take()
    {
        _releaseTween?.Kill();
        _startPos = transform.position;
    }

    public void Release()
    {
        MoveTo(ReturnStartPosition());
    }
    

    /*private void ToStartPosition()
    {
        _releaseTween = transform.DOMove(_startPos, 0.3f).SetEase(Ease.OutFlash)
            .SetAutoKill(false);

        transform.DOLocalRotate(Vector3.zero, 1f);
    }*/

    public void MoveTo(Vector3 move)
    {
        transform.DOMove(move, 0.3f).SetAutoKill();
    }
    
    public Vector2 ReturnStartPosition()
    {
        return _startPos;
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
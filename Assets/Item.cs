using DG.Tweening;
using UnityEngine;

public abstract class Item : MonoBehaviour, ITakeable
{
    private Tween _releaseTween;
    private Vector3 _startPos;

    /*public virtual void ReleaseObject()
    {
        _releaseTween = transform.DOMove(_startPos, 0.3f).SetEase(Ease.OutFlash)
            .SetAutoKill(false);

        transform.DOLocalRotate(Vector3.zero, 1f);
    }

    public virtual void TakeObject()
    {
        _releaseTween?.Kill();
        _startPos = transform.position;
    }*/

    public void Take()
    {
        _releaseTween?.Kill();
        _startPos = transform.position;
    }

    public void Release()
    {
        _releaseTween = transform.DOMove(_startPos, 0.3f).SetEase(Ease.OutFlash)
            .SetAutoKill(false);

        transform.DOLocalRotate(Vector3.zero, 1f);
    }
}
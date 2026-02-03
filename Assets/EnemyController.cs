using UnityEngine;

public class EnemyController : PlayableCard
{
    
    public void SetInfo(PlayableCardObject cardInfo)
    {
        _playableCardInfo = cardInfo;

        _faceSprite = _playableCardInfo.FaceSprite;
        _backSprite = _playableCardInfo.BackSprite;

        _currentSuit = _playableCardInfo.CurrentSuit;
        _cost = _playableCardInfo.Cost;
        _type = _playableCardInfo.Type;
       // _spriteRenderer.sprite = _faceSprite;
    }
    
    
    
    
}

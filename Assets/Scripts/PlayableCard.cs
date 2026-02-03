using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayableCard : Card
{
    protected PlayableCardObject _playableCardInfo;

    private CardHolderController _currentHolder;

    protected Sprite _faceSprite;
    protected Sprite _backSprite;
    protected SuitObject _currentSuit;
    protected int _cost;
    protected CardType _type;

    public void SetHolder(CardHolderController holder)
    {
        _currentHolder = holder;
    }

    public CardHolderController CardHolder()
    {
        return _currentHolder;
    }

    private SpriteRenderer _spriteRenderer;

    private void OnEnable()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _itemSway = GetComponentInChildren<ItemSway>();
    }

    private CardHolderController _previousHolder;

    private void OnTriggerStay2D(Collider2D other)
    {
        var holder = other.GetComponent<CardHolderController>();
        if (holder == null)
            return;

        _previousHolder = _currentHolder;

        _currentHolder = holder;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var holder = other.GetComponent<CardHolderController>();
        if (holder == null || holder != _currentHolder)
            return;

        _currentHolder = _previousHolder;
    }

    public void SetInfo(PlayableCardObject cardInfo)
    {
        _playableCardInfo = cardInfo;

        _faceSprite = _playableCardInfo.FaceSprite;
        _backSprite = _playableCardInfo.BackSprite;

        _currentSuit = _playableCardInfo.CurrentSuit;
        _cost = _playableCardInfo.Cost;
        _type = _playableCardInfo.Type;
        _spriteRenderer.sprite = _faceSprite;
    }

    public override void Release()
    {
        CardHolder().AddCard(this);
        CardHolder().SortItems();
    }
}
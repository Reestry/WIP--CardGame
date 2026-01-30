using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayableCard : Card
{
    [SerializeField] private PlayableCardObject _playableCardInfo;

    private CardHolderController _currentHolder;

    public void SetHolder(CardHolderController holder)
    {
        _currentHolder = holder;
    }

    public CardHolderController CardHolder()
    {
        return _currentHolder;
    }

    private Sprite _faceSprite;
    private Sprite _backSprite;
    private SuitObject _currentSuit;
    private int _cost;
    private CardType _type;

    [SerializeField] private List<PlayableCardObject> _cards;

    private void Start()
    {
        var i = Random.Range(0, _cards.Count);
        _playableCardInfo = _cards[i];

        base.Start();

        _faceSprite = _playableCardInfo.FaceSprite;
        _backSprite = _playableCardInfo.BackSprite;

        _currentSuit = _playableCardInfo.CurrentSuit;
        _cost = _playableCardInfo.Cost;
        _type = _playableCardInfo.Type;

        GetComponentInChildren<SpriteRenderer>().sprite = _faceSprite;
        _itemSway = GetComponentInChildren<ItemSway>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var holder = other.GetComponent<CardHolderController>();
        if (holder == null)
            return;
    }

    public void SetInfo(PlayableCardObject cardInfo)
    {
        _playableCardInfo = cardInfo;
    }
}
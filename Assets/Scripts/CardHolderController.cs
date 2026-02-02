using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CardHolderController : MonoBehaviour
{
    [SerializeField] private float _indentation;

    [SerializeField] private Transform _handHolder;
    [SerializeField] private Transform _center;
    private List<PlayableCard> _hand = new();

    public void AddCard(PlayableCard card)
    {
        card.SetHolder(this);
        _hand.Add(card);
        card.transform.SetParent(_handHolder);

        SortItems();
    }

    public void SortItems()
    {
        if (_hand.Count == 0)
            return;

        var totalWidth = (_hand.Count - 1) * _indentation;

        var startX = _center.position.x - totalWidth / 2f;

        for (var i = 0; i < _hand.Count; i++)
        {
            var card = _hand[i];
            var targetPos = new Vector3(startX + i * _indentation, _center.position.y, _center.position.z);

            card.MoveTo(targetPos);
        }
    }

    public void DeleteCard(PlayableCard card)
    {
        _hand.Remove(card);
        SortItems();
    }

    protected void ClearHand()
    {
        foreach (var card in _hand)
        {
            card.KillTweens();
            Destroy(card.gameObject);
        }

        _hand.Clear();
    }
}
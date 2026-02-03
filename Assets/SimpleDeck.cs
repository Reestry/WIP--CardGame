using System.Collections.Generic;
using UnityEngine;

public class SimpleDeck : MonoBehaviour
{
    protected List<PlayableCardObject> _deck = new();

    public PlayableCardObject ReturnCard()
    {
        if (_deck.Count == 0)
            return null;

        var rndCard = Random.Range(0, _deck.Count);

        var cardObj = _deck[rndCard];

        _deck.Remove(cardObj);
        return cardObj;
    }

    public void AddCard(PlayableCardObject card)
    {
        _deck.Add(card);
    }
}
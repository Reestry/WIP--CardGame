using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayableDeckController : SimpleDeck
{
    // DEBUG
    [SerializeField] private DeckObject _deckObject;

    private void Start()
    {
        SetDeck(_deckObject);
    }
    //

    public void SetDeck(DeckObject deckObject)
    {
        foreach (var card in deckObject.Deck)
            _deck.Add(card);
    }
}
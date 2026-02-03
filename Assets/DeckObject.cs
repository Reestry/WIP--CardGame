using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Deck", menuName = "Cards / decks")]
public class DeckObject : ScriptableObject
{

    [SerializeField] private List<PlayableCardObject> _deck = new();

    public List<PlayableCardObject> Deck => _deck;
}

using System.Threading.Tasks;
using UnityEngine;

public class Player_CardHolder : CardHolderController
{
    [SerializeField] private GameObject _cardPrefab;
    [SerializeField] private Transform _deckPosition;
    private int _cardCount = 8;

    private InputSystem_Actions _input;

    private PlayableDeckController _deck;

    private void Start()
    {
        _input = new InputSystem_Actions();
        _input.Enable();
        _deck = GetComponentInChildren<PlayableDeckController>();

        CreateHand(_cardCount);
    }

    private async Task CreateHand(int value)
    {
        // TODO set start position from deck
        await Task.Delay(1000);
        for (var i = 0; i <= value; i++)
        {
            CreateCard();
            await Task.Delay(100);
        }
    }

    private void CreateCard()
    {
        var card = Instantiate(_cardPrefab).GetComponent<PlayableCard>();

        card.SetInfo(_deck.ReturnCard());
        card.transform.position = _deckPosition.position;

        AddCard(card);
    }
}
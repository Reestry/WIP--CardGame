using System.Threading.Tasks;
using UnityEngine;

public class Player_CardHolder : CardHolderController
{
    [SerializeField] private GameObject _cardPrefab;
    [SerializeField] private Transform _deckPosition;

    private InputSystem_Actions _input;

    private void Start()
    {
        _input = new InputSystem_Actions();
        _input.Enable();

        CrerateCard();
    }

    private void Update()
    {
        if (_input.Player.Debug_CreateCard.WasPressedThisFrame())
        {
            CreateCard();
        }

        if (_input.Player.Debug_ClearHand.WasPressedThisFrame())
        {
            ClearHand();
            SortItems();
        }
    }

    // TODO move to new class like CardCreator
    private async Task CrerateCard()
    {
        // TODO set start position from deck
        await Task.Delay(1000);
        for (var i = 0; i <= 8; i++)
        {
            CreateCard();
            await Task.Delay(100);
        }
    }

    private void CreateCard()
    {
        var card = Instantiate(_cardPrefab).GetComponent<PlayableCard>();
        card.transform.position = _deckPosition.position;

        AddCard(card);
    }
}
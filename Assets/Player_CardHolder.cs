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
    }

    private void Update()
    {
        if (_input.Player.Debug_CreateCard.WasPressedThisFrame())
        {
            CrerateCard();
        }

        if (_input.Player.Debug_ClearHand.WasPressedThisFrame())
        {
            ClearHand();
            SortItems();
        }
    }

    // TODO move to new class like CardCreator
    private void CrerateCard()
    {
        // TODO set start position from deck

        var card = Instantiate(_cardPrefab).GetComponent<PlayableCard>();
        card.transform.position = _deckPosition.position;

        AddCard(card);
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    [SerializeField] private GameObject _cardPrefab;

    private List<PlayableCard> _hand;

    private void CrerateCard()
    {
        var card = Instantiate(_cardPrefab, gameObject.transform, true).GetComponent<PlayableCard>();
        
        _hand.Add(card);
        card.transform.position = transform.position;
    }

    private void ClearHand()
    {
        foreach (var card in _hand)
        {
            Destroy(card);
        }

        _hand.Clear();
    }


    // Debug
    
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
        }
    }
}
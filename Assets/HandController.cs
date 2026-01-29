using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HandController : MonoBehaviour
{
    [SerializeField] private GameObject _cardPrefab;

    private List<PlayableCard> _hand = new();
    [SerializeField] private float _indentation;

    [SerializeField] private Transform _handHolder;
    [SerializeField] private Transform _center;
    private Vector3 _handStartPos;

    private void CrerateCard()
    {
        var card = Instantiate(_cardPrefab, gameObject.transform, true).GetComponent<PlayableCard>();

        _hand.Add(card);
        card.transform.SetParent(_handHolder);

        
        // TODO set to deck
        card.transform.position = transform.position;
        
        
        card.transform.position = new Vector3(card.transform.position.x + _currentIndent, card.transform.position.y,
            card.transform.position.z);
        _currentIndent += _indentation;

        /*transform.DOMove(new Vector3(transform.position.x - 0.2f, transform.position.y, transform.position.z),
            1).SetAutoKill(true);*/
    }

    private void ClearHand()
    {
        foreach (var card in _hand)
        {
            card.KillTweens();
            Destroy(card.gameObject);
        }

        _hand.Clear();
        _currentIndent = 0;
        transform.position = _handStartPos;
    }

    private float _currentIndent;

    private void SortItems()
    {
        if (_hand.Count <= 1)
            return;
        
        //_center.SetParent(_handHolder);
        //_handHolder.SetParent(_center);
        //_handHolder.localPosition = new Vector3(0, _handHolder.position.y);
        //_handHolder.SetParent(transform);
    }

    // Debug

    private InputSystem_Actions _input;

    private void Start()
    {
        _handStartPos = transform.position;

        _input = new InputSystem_Actions();
        _input.Enable();
    }

    private void Update()
    {
        if (_input.Player.Debug_CreateCard.WasPressedThisFrame())
        {
            CrerateCard();
            SortItems();
        }

        if (_input.Player.Debug_ClearHand.WasPressedThisFrame())
        {
            ClearHand();
            SortItems();
        }
    }
}
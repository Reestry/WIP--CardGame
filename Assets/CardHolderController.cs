using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CardHolderController : MonoBehaviour
{
    [SerializeField] private GameObject _cardPrefab;

    private List<PlayableCard> _hand = new();
    [SerializeField] private float _indentation;

    [SerializeField] private Transform _handHolder;
    [SerializeField] private Transform _center;
    private Vector3 _handStartPos;

    // TODO move to new class like CardCreator
    private void CrerateCard()
    {
        // TODO set start position from deck

        var card = Instantiate(_cardPrefab, gameObject.transform, true).GetComponent<PlayableCard>();
        AddCard(card);

        /*transform.DOMove(new Vector3(transform.position.x - 0.2f, transform.position.y, transform.position.z),
            1).SetAutoKill(true);*/
    }

    public void AddToList(PlayableCard card)
    {
        _hand.Add(card);
    }

    public void AddCard(PlayableCard card)
    {
        card.SetHolder(this);
        _hand.Add(card);
        card.transform.SetParent(_handHolder);

        //card.transform.position = transform.position;

        SortItems();
        /*var pos = new Vector2(card.transform.position.x + _currentIndent, card.transform.position.y);

        card.SetStartPos(pos);
        _currentIndent += _indentation;

        card.MoveTo(pos);*/

        /*

         card.transform.position = new Vector3(card.transform.position.x + _currentIndent, card.transform.position.y,
            card.transform.position.z);
        _currentIndent += _indentation;
        */
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

    private void ClearHand()
    {
        foreach (var card in _hand)
        {
            card.KillTweens();
            Destroy(card.gameObject);
        }

        _hand.Clear();

        transform.position = _handStartPos;
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
        }

        if (_input.Player.Debug_ClearHand.WasPressedThisFrame())
        {
            ClearHand();
            SortItems();
        }
    }
}
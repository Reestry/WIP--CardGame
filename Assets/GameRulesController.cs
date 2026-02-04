using System;
using UnityEngine;
using UnityEngine.UI;

public class GameRulesController : MonoBehaviour
{
    [SerializeField] private Button _runButton;

    [SerializeField] private EnemyController _enemy;
    [SerializeField] private CardHolderController _cards;

    private void Awake()
    {
        _runButton.onClick.AddListener(Run);
    }

    private void Run()
    {
        if (!CheckPlace())
            return;

        var damage = 0;

        foreach (var card in _cards.GetInfo())
            damage += card.GetDamage();

        _enemy.TakeDamage(damage);
    }

    private bool CheckPlace()
    {
        var cardCount = _cards.GetInfo().Count;
        switch (cardCount)
        {
        case 0:
        case > 1 when _cards.GetInfo()[0].GetDamage() != _cards.GetInfo()[cardCount - 1].GetDamage():
            return false;
        }

        return true;
    }
}
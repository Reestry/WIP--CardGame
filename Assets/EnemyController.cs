using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : PlayableCard
{
    [SerializeField] private List<PlayableCardObject> _card = new();

    [SerializeField] private TMP_Text _damageText;
    [SerializeField] private TMP_Text _healthText;

    [SerializeField] private SpriteRenderer _faceSprite;

    private void Start()
    {
        var rnd = Random.Range(0, _card.Count);

        SetInfo(_card[rnd]);
    }

    private int _health;

    public void SetInfo(PlayableCardObject cardInfo)
    {
        _playableCardInfo = cardInfo;

        _faceSprite.sprite = _playableCardInfo.FaceSprite;
        _backSprite = _playableCardInfo.BackSprite;

        _currentSuit = _playableCardInfo.CurrentSuit;
        _cost = _playableCardInfo.Cost;
        _health = _cost * 2;

        _healthText.text = _health.ToString();
        _damageText.text = _cost.ToString();
    }
}
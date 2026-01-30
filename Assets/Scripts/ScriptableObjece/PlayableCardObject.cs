using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Cards / playable")]
public class PlayableCardObject : ScriptableObject
{
    [SerializeField] private Sprite _faceSprite;
    [SerializeField] private Sprite _backSprite;
    [SerializeField] private SuitObject _currentSuit;
    [SerializeField] private int _cost;
    [SerializeField] private CardType _type;

    public Sprite FaceSprite => _faceSprite;
    public Sprite BackSprite => _backSprite;
    public SuitObject CurrentSuit => _currentSuit;
    public int Cost => _cost;
    public CardType Type => _type;
}

public enum CardType
{
    King,
    Queen,
    Jack,
    Ace, 
    Number
}
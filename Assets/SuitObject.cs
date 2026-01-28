using UnityEngine;

[CreateAssetMenu(fileName = "Suit", menuName = "Cards/Suit")]
public class SuitObject : ScriptableObject
{
    [SerializeField] private int _suitId;
    [SerializeField] private string _suitName;
    [SerializeField] private Color _suitColor;


    public int SuitId => _suitId;
    public string SuitName => _suitName;
    public Color SuitColor => _suitColor;
}

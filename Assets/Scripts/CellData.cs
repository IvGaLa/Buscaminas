using System.Numerics;
using UnityEngine;

public class CellData
{
    bool _hasBomb;          // Si es una bomba
    bool _isRevealed;       // Si la celda fue revelada
    Vector2Int _position;   // Posición en el grid

    // Setters/Getters
    public bool HasBomb { get => _hasBomb; set => _hasBomb = value; }
    public bool IsRevealed { get => _isRevealed; set => _isRevealed = value; }
    public Vector2Int Position { get => _position; set => _position = value; }
}
using UnityEngine;

public class CellData
{
    Vector3 _position;      // Posición en el grid
    bool _hasBomb;          // Si es una bomba
    bool _isRevealed;       // Si la celda fue revelada
    int _gridPositionX, _gridPositionY;   // Posición (X,Y) en el grid

    // Setters/Getters
    public Vector3 Position { get => _position; set => _position = value; }
    public bool HasBomb { get => _hasBomb; set => _hasBomb = value; }
    public bool IsRevealed { get => _isRevealed; set => _isRevealed = value; }
    public int GridPositionX { get => _gridPositionX; set => _gridPositionX = value; }
    public int GridPositionY { get => _gridPositionY; set => _gridPositionY = value; }
}
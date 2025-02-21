using UnityEngine;

public class Cell : MonoBehaviour
{
    spritesNamesTypes _newSprite;
    Vector3 _position;      // Posición en el grid
    bool _hasBomb;          // Si es una bomba
    int _adjacentBombs;     // Bombas cercanas
    bool _isRevealed;       // Si la celda fue revelada
    int _gridPositionX;   // Posición en el grid
    int _gridPositionY;   // Posición en el grid

    // Setters/Getters
    public Vector3 Position { get => _position; set => _position = value; }
    public bool HasBomb { get => _hasBomb; set => _hasBomb = value; }
    public int AdjacentBombs { get => _adjacentBombs; set => _adjacentBombs = value; }
    public bool IsRevealed { get => _isRevealed; set => _isRevealed = value; }
    public int GridPositionX { get => _gridPositionX; set => _gridPositionX = value; }
    public int GridPositionY { get => _gridPositionY; set => _gridPositionY = value; }

    // Método para revelar la celda
    void Reveal()
    {
        _isRevealed = true;
        if (_hasBomb)
        {
            // TO-DO: Gestionar Game over
            _newSprite = spritesNamesTypes.BOMB_1;
        }
        else
        {
            // TO-DO: Revelar celdas adyacentes
            _newSprite = BombNumbers.GetBombNumbers()[CheckAdjacentBombs()];
        }
    }

    int CheckAdjacentBombs()
    {
        int bombs = 0;
        foreach (var direction in Directions.GetDirections())
        {
            Vector3 newPosition = new(_gridPositionX + direction.Value.x, _gridPositionY + direction.Value.y);
            if (GameManager.CheckHasBomb(newPosition))
                bombs++;
        }

        return bombs;
    }

    void OnMouseDown()
    {
        if (!_isRevealed)
        {
            Reveal();
            ChangeSprite(_newSprite);
        }
    }

    void ChangeSprite(spritesNamesTypes newSprite = spritesNamesTypes._0)
    {
        GetComponent<SpriteRenderer>().sprite = SpritesNamesVariables.GetSprite()[newSprite];
    }
}

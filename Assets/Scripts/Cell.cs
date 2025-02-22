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
  void Reveal(int x, int y)
  {

    // Si ya está revelada, no hacer nada
    if (_isRevealed) return;

    IsRevealed = true;
    GameManager.AddCellRevealed();
    int countBombs = CountBombs(x, y);

    if (countBombs == 0)
    {
      foreach (var direction in Directions.GetDirections())
      {
        int dx = direction.Value.x;
        int dy = direction.Value.y;
        int nx = x + dx;
        int ny = y + dy;

        if (!GameManager.CheckHasBomb(nx, ny))
        {
          Reveal(nx, ny);
        }
      }
    }

    ChangeSprite((spritesNamesTypes)countBombs);
  }

  int CountBombs(int x, int y)
  {
    int bombs = 0;
    foreach (var direction in Directions.GetDirections())
    {
      int nx = x + direction.Value.x;
      int ny = y + direction.Value.y;
      if (GameManager.CheckHasBomb(nx, ny))
        bombs++;
    }

    return bombs;
  }


  void OnMouseDown()
  {
    if (HasBomb)
    {
      ChangeSprite(spritesNamesTypes.BOMB_1);
      GameManager.GameOver();
    }

    Reveal(GridPositionX, GridPositionY);
  }

  void ChangeSprite(spritesNamesTypes newSprite = spritesNamesTypes._0)
  {
    GetComponent<SpriteRenderer>().sprite = SpritesNamesVariables.GetSprite()[newSprite];
  }
}

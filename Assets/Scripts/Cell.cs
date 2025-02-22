using UnityEngine;

public class Cell : MonoBehaviour
{
  CellData _cellData;

  public void InitializeCellData(CellData cellData)
  {
    _cellData = cellData;
  }

  // Método para revelar la celda
  void Reveal(int x, int y)
  {

    // Si ya está revelada, no hacer nada
    if (_cellData.IsRevealed) return;

    _cellData.IsRevealed = true;
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
    if (_cellData.HasBomb)
    {
      ChangeSprite(spritesNamesTypes.BOMB_1);
      GameManager.GameOver();
    }

    Reveal(_cellData.GridPositionX, _cellData.GridPositionY);
  }

  void ChangeSprite(spritesNamesTypes newSprite = spritesNamesTypes._0)
  {
    GetComponent<SpriteRenderer>().sprite = SpritesNamesVariables.GetSprite()[newSprite];
  }
}

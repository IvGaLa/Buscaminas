using UnityEngine;

public class Cell : MonoBehaviour
{
  CellData _cellData;

  public void InitializeCellData(CellData cellData)
  {
    _cellData = cellData;
  }

  // Método para revelar la celda
  void Reveal(Vector2Int position)
  {
    _cellData.IsRevealed = true;
    GameManager.AddCellRevealed();
    int x = position.x;
    int y = position.y;
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
          Reveal(new Vector2Int(nx, ny));
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


  void ToggleFlag()
  {
    _cellData.HasFlag = !_cellData.HasFlag;
    spritesNamesTypes _newSprite = (_cellData.HasFlag) ? spritesNamesTypes.FLAG : spritesNamesTypes.UNREVEALED;
    ChangeSprite(_newSprite);
  }

  //void OnMouseDown()
  void OnMouseOver()
  {
    // Si ya está revelada, no hacer nada
    if (_cellData.IsRevealed) return;

    if (Input.GetMouseButtonDown(1)) // Right click
    {
      ToggleFlag();
    }
    else if (Input.GetMouseButtonDown(0)) // Left click
    {
      if (_cellData.HasFlag) return;

      if (_cellData.HasBomb)
      {
        ChangeSprite(spritesNamesTypes.BOMB_1);
        GameManager.GameOver();
        return;
      }

      Reveal(_cellData.Position);

    }
  }

  void ChangeSprite(spritesNamesTypes newSprite = spritesNamesTypes._0)
  {
    GetComponent<SpriteRenderer>().sprite = SpritesNamesVariables.GetSprite()[newSprite];
  }
}

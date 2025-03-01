using UnityEngine;

public class Cell : MonoBehaviour
{
  CellData _cellData;
  public CellData CellData { get => _cellData; set => _cellData = value; }
  public void ChangeSprite(spritesNamesTypes newSprite = spritesNamesTypes._0) => GetComponent<SpriteRenderer>().sprite = SpritesNamesVariables.GetSprite()[newSprite];
  public void InitializeCellData(CellData cellData) => _cellData = cellData;
  void Reveal() => GameManager.Instance.RevealCell(this);
  public int CountBombs(int x, int y)
  {
    int bombs = 0;
    foreach (var direction in Directions.GetDirections())
    {
      int nx = x + direction.Value.x;
      int ny = y + direction.Value.y;
      if (GameManager.Instance.CheckHasBomb(nx, ny))
        bombs++;
    }
    return bombs;
  }


  void HandleRightClick()
  {
    _cellData.HasFlag = !_cellData.HasFlag;
    spritesNamesTypes _newSprite = _cellData.HasFlag ? spritesNamesTypes.FLAG : spritesNamesTypes.UNREVEALED;
    ChangeSprite(_newSprite);
  }

  void OnMouseOver()
  {
    // Si no se está jugando o la celda ya fue revelada, no hacer nada
    if ((!GameManager.Instance.Playing) || _cellData.IsRevealed) return;
    HandleClick();
  }


  void HandleClick()
  {
    if (Input.GetMouseButtonDown(1)) // Right click
      HandleRightClick();
    else if (Input.GetMouseButtonDown(0)) // Left click
      HandleLeftClick();
  }

  void HandleLeftClick()
  {
    if (_cellData.HasFlag) return;

    if (_cellData.HasBomb)
      HandleHasBomb();
    else
      Reveal();

  }

  void HandleHasBomb()
  {
    ChangeSprite(spritesNamesTypes.BOMB_2);
    GameManager.Instance.GameOver(this);
  }

}
using System.Collections.Generic;

public static class BombNumbers
{
  public static Dictionary<int, spritesNamesTypes> GetBombNumbers()
  {
    Dictionary<int, spritesNamesTypes> _bombNumbers = new() {
      {0, spritesNamesTypes._0},
      {1, spritesNamesTypes._1},
      {2, spritesNamesTypes._2},
      {3, spritesNamesTypes._3},
      {4, spritesNamesTypes._4},
      {5, spritesNamesTypes._5},
      {6, spritesNamesTypes._6},
      {7, spritesNamesTypes._7},
      {8, spritesNamesTypes._8},
    };
    return _bombNumbers;
  }
}
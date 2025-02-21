using System.Collections.Generic;
public static class SpritesNamesVariables
{
  public static Dictionary<spritesNamesTypes, string> GetPrefabsNames()
  {
    Dictionary<spritesNamesTypes, string> _spritesNames = new() {
      {spritesNamesTypes._0, "0"},
      {spritesNamesTypes._1, "1"},
      {spritesNamesTypes._2, "2"},
      {spritesNamesTypes._3, "3"},
      {spritesNamesTypes._4, "4"},
      {spritesNamesTypes._5, "5"},
      {spritesNamesTypes._6, "6"},
      {spritesNamesTypes._7, "7"},
      {spritesNamesTypes._8, "8"},
      {spritesNamesTypes.BOMB_1, "bomb_1"},
      {spritesNamesTypes.BOMB_2, "bomb_2"},
      {spritesNamesTypes.BOMB_3, "bomb_3"},
      {spritesNamesTypes.FLAG, "flag"},
      {spritesNamesTypes.QUESTION_1, "question_1"},
      {spritesNamesTypes.QUESTION_2, "question_2"},
      {spritesNamesTypes.UNREVEALED, "unrevealed"},
    };
    return _spritesNames;
  }
}
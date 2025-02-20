using System.Collections.Generic;
public static class PrefabsCellsNamesVariables
{
  public static Dictionary<prefabsCellsNamesTypes, string> GetPrefabsNames()
  {
    Dictionary<prefabsCellsNamesTypes, string> _cellsNames = new() {
      {prefabsCellsNamesTypes._0, "0"},
      {prefabsCellsNamesTypes._1, "1"},
      {prefabsCellsNamesTypes._2, "2"},
      {prefabsCellsNamesTypes._3, "3"},
      {prefabsCellsNamesTypes._4, "4"},
      {prefabsCellsNamesTypes._5, "5"},
      {prefabsCellsNamesTypes._6, "6"},
      {prefabsCellsNamesTypes._7, "7"},
      {prefabsCellsNamesTypes._8, "8"},
      {prefabsCellsNamesTypes.BOMB_1, "bomb_1"},
      {prefabsCellsNamesTypes.BOMB_2, "bomb_2"},
      {prefabsCellsNamesTypes.BOMB_3, "bomb_3"},
      {prefabsCellsNamesTypes.FLAG, "flag"},
      {prefabsCellsNamesTypes.QUESTION_1, "question_1"},
      {prefabsCellsNamesTypes.QUESTION_2, "question_2"},
      {prefabsCellsNamesTypes.UNREVEALED, "unrevealed"},
    };
    return _cellsNames;
  }
}
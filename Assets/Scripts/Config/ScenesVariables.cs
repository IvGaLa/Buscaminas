using System.Collections.Generic;

public static class ScenesVariables
{
  public static Dictionary<scenesTypes, string> GetScenesVariables()
  {
    Dictionary<scenesTypes, string> _sceneName = new() {
      {scenesTypes.MAIN, "Main"},
      {scenesTypes.GAME, "Game"},
      {scenesTypes.WIN, "Win"},
      {scenesTypes.LOSE, "Lose"},
    };
    return _sceneName;
  }
}
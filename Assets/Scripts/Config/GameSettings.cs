using System.Collections.Generic;

public static class GameSettings
{
  public static Dictionary<difficultyTypes, (int width, int height, int bombs)> GetGameSettings()
  {
    Dictionary<difficultyTypes, (int width, int height, int bombs)> _gameSettings = new() {
      {difficultyTypes.EASY, (width: 10, height: 10, bombs: 10)},
      {difficultyTypes.MEDIUM, (width: 20, height: 20, bombs: 40)},
      {difficultyTypes.HARD, (width: 30, height: 30, bombs: 99)},
    };
    return _gameSettings;
  }
}
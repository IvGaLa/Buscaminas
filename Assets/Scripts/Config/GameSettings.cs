using System.Collections.Generic;

public static class GameSettings
{
  public static Dictionary<difficultyTypes, (int width, int height, int bombs, int camSize)> GetGameSettings()
  {
    Dictionary<difficultyTypes, (int width, int height, int bombs, int camSize)> _gameSettings = new() {
      {difficultyTypes.EASY, (width: 10, height: 10, bombs: 10, camSize: 10)},
      {difficultyTypes.MEDIUM, (width: 20, height: 20, bombs: 40, camSize: 15)},
      {difficultyTypes.HARD, (width: 30, height: 30, bombs: 99, camSize: 20)},
    };
    return _gameSettings;
  }


}
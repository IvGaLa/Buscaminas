using System.Collections.Generic;
public static class GameSettings
{
  static readonly Dictionary<gameSettingsTypes, GameSettingsValues> _gameSettings = new()
    {
        { gameSettingsTypes.EASY, new GameSettingsValues(new Dictionary<gameSettingsTypes, int>{{gameSettingsTypes.BOMBS,10},{gameSettingsTypes.HEIGHT, 10},{gameSettingsTypes.WIDTH, 10}}) },
        { gameSettingsTypes.MEDIUM, new GameSettingsValues(new Dictionary<gameSettingsTypes, int>{{gameSettingsTypes.BOMBS,40},{gameSettingsTypes.HEIGHT, 20},{gameSettingsTypes.WIDTH, 20}}) },
        { gameSettingsTypes.HARD, new GameSettingsValues(new Dictionary<gameSettingsTypes, int>{{gameSettingsTypes.BOMBS,99},{gameSettingsTypes.HEIGHT, 30},{gameSettingsTypes.WIDTH, 30}}) }
    };

  public static GameSettingsValues GetGameSettings(gameSettingsTypes difficulty) => _gameSettings[difficulty];
}

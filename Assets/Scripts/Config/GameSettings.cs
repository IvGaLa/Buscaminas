using System.Collections.Generic;
public static class GameSettings
{
  static readonly Dictionary<gameSettingsTypes, GameSettingsValues> _gameSettings = new()
    {
      {
        gameSettingsTypes.EASY, new GameSettingsValues(
          new Dictionary<gameSettingsTypes, GameSettingValue>
          {
            {gameSettingsTypes.BOMBS,new GameSettingValue(10)},
            {gameSettingsTypes.HEIGHT, new GameSettingValue(10)},
            {gameSettingsTypes.WIDTH,new GameSettingValue(10)},
            {gameSettingsTypes.NAME,new GameSettingValue("Easy")}
          }
      )},
      {
        gameSettingsTypes.MEDIUM, new GameSettingsValues(
          new Dictionary<gameSettingsTypes, GameSettingValue>
          {
            {gameSettingsTypes.BOMBS,new GameSettingValue(40)},
            {gameSettingsTypes.HEIGHT, new GameSettingValue(20)},
            {gameSettingsTypes.WIDTH,new GameSettingValue(20)},
            {gameSettingsTypes.NAME,new GameSettingValue("Medium")}
          }
      )},
      {
        gameSettingsTypes.HARD, new GameSettingsValues(
          new Dictionary<gameSettingsTypes, GameSettingValue>
          {
            {gameSettingsTypes.BOMBS,new GameSettingValue(99)},
            {gameSettingsTypes.HEIGHT, new GameSettingValue(30)},
            {gameSettingsTypes.WIDTH,new GameSettingValue(30)},
            {gameSettingsTypes.NAME,new GameSettingValue("Hard")}
          }
      )},
    };
  public static GameSettingsValues GetGameSettings(gameSettingsTypes difficulty) => _gameSettings[difficulty];
}

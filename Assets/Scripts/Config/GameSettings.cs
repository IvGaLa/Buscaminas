using System.Collections.Generic;
public static class GameSettings
{
  static readonly Dictionary<GameSettingsTypes, GameSettingsValues> _gameSettings = new()
    {
      {
        GameSettingsTypes.EASY, new GameSettingsValues(
          new Dictionary<GameSettingsTypes, GameSettingValue>
          {
            {GameSettingsTypes.BOMBS,new GameSettingValue(10)},
            {GameSettingsTypes.HEIGHT, new GameSettingValue(10)},
            {GameSettingsTypes.WIDTH,new GameSettingValue(10)},
            {GameSettingsTypes.NAME,new GameSettingValue("Easy")}
          }
      )},
      {
        GameSettingsTypes.MEDIUM, new GameSettingsValues(
          new Dictionary<GameSettingsTypes, GameSettingValue>
          {
            {GameSettingsTypes.BOMBS,new GameSettingValue(40)},
            {GameSettingsTypes.HEIGHT, new GameSettingValue(20)},
            {GameSettingsTypes.WIDTH,new GameSettingValue(20)},
            {GameSettingsTypes.NAME,new GameSettingValue("Medium")}
          }
      )},
      {
        GameSettingsTypes.HARD, new GameSettingsValues(
          new Dictionary<GameSettingsTypes, GameSettingValue>
          {
            {GameSettingsTypes.BOMBS,new GameSettingValue(99)},
            {GameSettingsTypes.HEIGHT, new GameSettingValue(30)},
            {GameSettingsTypes.WIDTH,new GameSettingValue(30)},
            {GameSettingsTypes.NAME,new GameSettingValue("Hard")}
          }
      )},
    };
  public static GameSettingsValues GetGameSettings(GameSettingsTypes difficulty) => _gameSettings[difficulty];
}

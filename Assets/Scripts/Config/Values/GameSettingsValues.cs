using System.Collections.Generic;

public class GameSettingsValues
{
  public int Width { get; }
  public int Height { get; }
  public int Bombs { get; }
  public string Name { get; }

  public GameSettingsValues(Dictionary<GameSettingsTypes, GameSettingValue> settings)
  {
    Width = settings.ContainsKey(GameSettingsTypes.WIDTH) ? settings[GameSettingsTypes.WIDTH].GetValue<int>() : 10;
    Height = settings.ContainsKey(GameSettingsTypes.HEIGHT) ? settings[GameSettingsTypes.HEIGHT].GetValue<int>() : 10;
    Bombs = settings.ContainsKey(GameSettingsTypes.BOMBS) ? settings[GameSettingsTypes.BOMBS].GetValue<int>() : 10;
    Name = settings.ContainsKey(GameSettingsTypes.NAME) ? settings[GameSettingsTypes.NAME].GetValue<string>() : "Easy";
  }

  public void Deconstruct(out int width, out int height, out int bombs, out string name)
  {
    width = Width;
    height = Height;
    bombs = Bombs;
    name = Name;
  }
}
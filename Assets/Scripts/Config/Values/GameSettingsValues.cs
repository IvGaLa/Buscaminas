using System.Collections.Generic;

public class GameSettingsValues
{
  public int Width { get; }
  public int Height { get; }
  public int Bombs { get; }
  public string Name { get; }

  public GameSettingsValues(Dictionary<gameSettingsTypes, GameSettingValue> settings)
  {
    Width = settings.ContainsKey(gameSettingsTypes.WIDTH) ? settings[gameSettingsTypes.WIDTH].GetValue<int>() : 10;
    Height = settings.ContainsKey(gameSettingsTypes.HEIGHT) ? settings[gameSettingsTypes.HEIGHT].GetValue<int>() : 10;
    Bombs = settings.ContainsKey(gameSettingsTypes.BOMBS) ? settings[gameSettingsTypes.BOMBS].GetValue<int>() : 10;
    Name = settings.ContainsKey(gameSettingsTypes.NAME) ? settings[gameSettingsTypes.NAME].GetValue<string>() : "Easy";
  }

  public void Deconstruct(out int width, out int height, out int bombs, out string name)
  {
    width = Width;
    height = Height;
    bombs = Bombs;
    name = Name;
  }
}
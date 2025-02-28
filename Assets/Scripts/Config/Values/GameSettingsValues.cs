using System.Collections.Generic;

public class GameSettingsValues
{
  public int Width { get; }
  public int Height { get; }
  public int Bombs { get; }

  public GameSettingsValues(Dictionary<gameSettingsTypes, int> settings)
  {
    Width = settings.ContainsKey(gameSettingsTypes.WIDTH) ? settings[gameSettingsTypes.WIDTH] : 10;
    Height = settings.ContainsKey(gameSettingsTypes.HEIGHT) ? settings[gameSettingsTypes.HEIGHT] : 10;
    Bombs = settings.ContainsKey(gameSettingsTypes.BOMBS) ? settings[gameSettingsTypes.BOMBS] : 10;
  }

  public void Deconstruct(out int width, out int height, out int bombs)
  {
    width = Width;
    height = Height;
    bombs = Bombs;
  }
}
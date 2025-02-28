using System.Collections.Generic;

public class ConfigVariables
{
  static readonly Dictionary<configTypes, object> _config = new()
    {
        { configTypes.PREFABS_CELLS_PATH, new ConfigValues<string>("Prefabs/") },
        { configTypes.SPRITES_PATH, new ConfigValues<string>("Sprites/") },
        { configTypes.PREFAB_CELL, new ConfigValues<string>("cell") },
        { configTypes.TILESET_NAME, new ConfigValues<string>("minesweeper") },
        { configTypes.DIFFICULTY, new ConfigValues<gameSettingsTypes>(gameSettingsTypes.EASY) }, // Default difficulty
        // { configTypes.MUSIC_ENABLED, new ConfigValues<bool>(true) },
        // { configTypes.VOLUME_LEVEL, new ConfigValues<int>(80) }
    };

  public static void SetConfigValue<T>(configTypes key, T newValue)
  {
    if (_config.TryGetValue(key, out object value) && value is ConfigValues<T> typedValue)
      typedValue.SetValue(newValue);
  }

  public static T GetConfigValue<T>(configTypes key)
  {
    if (_config.TryGetValue(key, out object value) && value is ConfigValues<T> typedValue)
      return typedValue.Value;

    throw new KeyNotFoundException($"Key {key} not found or invalid type.");
  }
}

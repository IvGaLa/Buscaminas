using System.Collections.Generic;

public static class ConfigVariables
{
  private static readonly Dictionary<configTypes, object> _config = new()
    {
        { configTypes.PREFABS_CELLS_PATH, new ConfigValue<string>("Prefabs/") },
        { configTypes.SPRITES_PATH, new ConfigValue<string>("Sprites/") },
        { configTypes.PREFAB_CELL, new ConfigValue<string>("cell") },
        { configTypes.TILESET_NAME, new ConfigValue<string>("minesweeper") },
        { configTypes.DIFFICULTY, new ConfigValue<difficultyTypes>(difficultyTypes.EASY) }, // Default difficulty
        // { configTypes.MUSIC_ENABLED, new ConfigValue<bool>(true) },
        // { configTypes.VOLUME_LEVEL, new ConfigValue<int>(80) }
    };

  public static void SetConfigValue<T>(configTypes key, T newValue)
  {
    if (_config.TryGetValue(key, out object value) && value is ConfigValue<T> typedValue)
      typedValue.SetValue(newValue);
    else
      throw new KeyNotFoundException($"Key {key} not found or invalid type.");

  }

  public static T GetConfigValue<T>(configTypes key)
  {
    if (_config.TryGetValue(key, out object value) && value is ConfigValue<T> typedValue)
      return typedValue.Value;

    throw new KeyNotFoundException($"Key {key} not found or invalid type.");
  }
}

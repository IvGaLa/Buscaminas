using System.Collections.Generic;

public class ConfigValue<T>
{
  public T Value { get; private set; }
  public ConfigValue(T value) => Value = value;
}

public static class ConfigVariables
{
  private static readonly Dictionary<configTypes, object> _config = new()
    {
        { configTypes.PREFABS_CELLS_PATH, new ConfigValue<string>("Prefabs/") },
        { configTypes.SPRITES_PATH, new ConfigValue<string>("Sprites/") },
        { configTypes.PREFAB_CELL, new ConfigValue<string>("cell") },
        { configTypes.TILESET_NAME, new ConfigValue<string>("minesweeper") },
        // { configTypes.MUSIC_ENABLED, new ConfigValue<bool>(true) },
        // { configTypes.VOLUME_LEVEL, new ConfigValue<int>(80) }
    };

  public static T GetConfigValue<T>(configTypes key)
  {
    if (_config.TryGetValue(key, out object value) && value is ConfigValue<T> typedValue)
      return typedValue.Value;

    throw new KeyNotFoundException($"Key {key} not found or invalid type.");
  }
}

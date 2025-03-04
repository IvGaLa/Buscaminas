using System.Collections.Generic;

public class ConfigVariables
{
  static readonly Dictionary<ConfigTypes, object> _config = new()
    {
        { ConfigTypes.AUTHOR, new ConfigValues<string>("IvGaLa") },
        { ConfigTypes.TITLE, new ConfigValues<string>("Buscaminas") },
        { ConfigTypes.GITHUB, new ConfigValues<string>("https://github.com/IvGaLa/Buscaminas") },

        { ConfigTypes.PREFABS_PATH, new ConfigValues<string>("Prefabs/") },
        { ConfigTypes.SPRITES_PATH, new ConfigValues<string>("Sprites/") },
        { ConfigTypes.MUSIC_PATH, new ConfigValues<string>("Audio/Music/") },
        { ConfigTypes.SFX_PATH, new ConfigValues<string>("Audio/SFX/") },

        { ConfigTypes.TILESET_NAME, new ConfigValues<string>("minesweeper") },

        { ConfigTypes.PREFAB_CELL, new ConfigValues<string>("cell") },
        { ConfigTypes.PREFAB_SFX_AUDIO_SOURCE, new ConfigValues<string>("SFXPlayer") },

        { ConfigTypes.DIFFICULTY, new ConfigValues<GameSettingsTypes>(GameSettingsTypes.EASY) }, // Default difficulty
        // { ConfigTypes.MUSIC_ENABLED, new ConfigValues<bool>(true) },
        // { ConfigTypes.VOLUME_LEVEL, new ConfigValues<int>(80) }
    };

  public static void SetConfigValue<T>(ConfigTypes key, T newValue)
  {
    if (_config.TryGetValue(key, out object value) && value is ConfigValues<T> typedValue)
      typedValue.SetValue(newValue);
  }

  public static T GetConfigValue<T>(ConfigTypes key)
  {
    if (_config.TryGetValue(key, out object value) && value is ConfigValues<T> typedValue)
      return typedValue.Value;

    throw new KeyNotFoundException($"Key {key} not found or invalid type.");
  }
}

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class SpritesNamesVariables
{
  static readonly Dictionary<SpritesNamesTypes, string> spritesNames = new()
    {
        { SpritesNamesTypes._0, "0" },
        { SpritesNamesTypes._1, "1" },
        { SpritesNamesTypes._2, "2" },
        { SpritesNamesTypes._3, "3" },
        { SpritesNamesTypes._4, "4" },
        { SpritesNamesTypes._5, "5" },
        { SpritesNamesTypes._6, "6" },
        { SpritesNamesTypes._7, "7" },
        { SpritesNamesTypes._8, "8" },
        { SpritesNamesTypes.BOMB_1, "bomb_1" },
        { SpritesNamesTypes.BOMB_2, "bomb_2" },
        { SpritesNamesTypes.BOMB_3, "bomb_3" },
        { SpritesNamesTypes.FLAG, "flag" },
        { SpritesNamesTypes.QUESTION_1, "question_1" },
        { SpritesNamesTypes.QUESTION_2, "question_2" },
        { SpritesNamesTypes.UNREVEALED, "unrevealed" },
    };

  static readonly Dictionary<SpritesNamesTypes, Sprite> spritesDictionary = LoadSprites();

  static Dictionary<SpritesNamesTypes, Sprite> LoadSprites()
  {
    string spritesPath = ConfigVariables.GetConfigValue<string>(ConfigTypes.SPRITES_PATH);
    string tilesetName = ConfigVariables.GetConfigValue<string>(ConfigTypes.TILESET_NAME);
    Sprite[] sprites = Resources.LoadAll<Sprite>(spritesPath + tilesetName);

    return spritesNames
        .Where(kv => sprites.Any(sprite => sprite.name == kv.Value))
        .ToDictionary(kv => kv.Key, kv => sprites.First(sprite => sprite.name == kv.Value));
  }

  public static Sprite GetSprite(SpritesNamesTypes spriteType) => spritesDictionary[spriteType];
}

using System.Collections.Generic;
using UnityEngine;
public static class SpritesNamesVariables
{
  readonly static Dictionary<spritesNamesTypes, string> spritesNames = new()
  {
    { spritesNamesTypes._0, "0" },
    { spritesNamesTypes._1, "1" },
    { spritesNamesTypes._2, "2" },
    { spritesNamesTypes._3, "3" },
    { spritesNamesTypes._4, "4" },
    { spritesNamesTypes._5, "5" },
    { spritesNamesTypes._6, "6" },
    { spritesNamesTypes._7, "7" },
    { spritesNamesTypes._8, "8" },
    { spritesNamesTypes.BOMB_1, "bomb_1" },
    { spritesNamesTypes.BOMB_2, "bomb_2" },
    { spritesNamesTypes.BOMB_3, "bomb_3" },
    { spritesNamesTypes.FLAG, "flag" },
    { spritesNamesTypes.QUESTION_1, "question_1" },
    { spritesNamesTypes.QUESTION_2, "question_2" },
    { spritesNamesTypes.UNREVEALED, "unrevealed" },
  };

  public static Dictionary<spritesNamesTypes, Sprite> GetSprite()
  {
    Sprite[] sprites = Resources.LoadAll<Sprite>(ConfigVariables.GetConfigValue<string>(configTypes.SPRITES_PATH) + ConfigVariables.GetConfigValue<string>(configTypes.TILESET_NAME));
    Dictionary<spritesNamesTypes, Sprite> _spritesNames = new();
    foreach (var sprite in sprites)
    {
      foreach (var key in spritesNames)
      {
        if (sprite.name == key.Value)
        {
          _spritesNames[key.Key] = sprite;
          break;
        }
      }
    }
    return _spritesNames;
  }
}
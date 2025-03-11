using System.Collections.Generic;
public class TilesetsVariables
{
  static readonly Dictionary<TilesetsTypes, string> _tilesets = new(){
    {TilesetsTypes.NORMAL, "minesweeper"},
    {TilesetsTypes.STONE, "minesweeper_stone"}
  };

  public static string GetTileset(TilesetsTypes tileset) => _tilesets[tileset];
}
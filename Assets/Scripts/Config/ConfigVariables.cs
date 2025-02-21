using System.Collections.Generic;
public static class ConfigVariables
{

  public static Dictionary<configTypes, string> GetConfigVariables()
  {
    Dictionary<configTypes, string> _config = new(){
      {configTypes.PREFABS_CELLS_PATH, "Prefabs/Cells/"},
      {configTypes.SPRITES_PATH, "Sprites/"},
      {configTypes.UNREVEALED_CELL, "unrevealed"}
    };

    return _config;
  }

}
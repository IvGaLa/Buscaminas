using System.Collections.Generic;
public class ScenesVariables
{
  static readonly Dictionary<scenesTypes, string> _sceneName = new(){
    {scenesTypes.MAIN, "Main"},
    {scenesTypes.GAME, "Game"}
  };
  public static Dictionary<scenesTypes, string> GetScenesVariables() => _sceneName;
}
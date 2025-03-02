using System.Collections.Generic;
public class ScenesVariables
{
  static readonly Dictionary<scenesTypes, string> _sceneName = new(){
    {scenesTypes.MAIN, "Main"},
    {scenesTypes.GAME, "Game"}
  };
  public static string GetScenesVariables(scenesTypes scene) => _sceneName[scene];
}
using System.Collections.Generic;
public class ScenesVariables
{
  static readonly Dictionary<ScenesTypes, string> _sceneName = new(){
    {ScenesTypes.MAIN, "Main"},
    {ScenesTypes.GAME, "Game"}
  };
  public static string GetScenesVariables(ScenesTypes scene) => _sceneName[scene];
}
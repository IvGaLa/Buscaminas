using System.Collections.Generic;
public class ScenesVariables
{
  static readonly Dictionary<scenesTypes, string> _sceneName = new(){
    {scenesTypes.MAIN, "Main"},
    {scenesTypes.GAME, "Game"},
    {scenesTypes.WIN, "Win"},
    {scenesTypes.LOSE, "Lose"}
  };
  public static Dictionary<scenesTypes, string> GetScenesVariables() => _sceneName;
}
using System.Collections.Generic;
public class Tags
{
  static readonly Dictionary<tagsTypes, string> _tags = new(){
    {tagsTypes.UNTAGGED, "Untagged"},
    {tagsTypes.RESPAWN, "Respawn"},
    {tagsTypes.FINISH, "Finish"},
    {tagsTypes.EDITORONLY, "EditorOnly"},
    {tagsTypes.MAINCAMERA, "MainCamera"},
    {tagsTypes.PLAYER, "Player"},
    {tagsTypes.GAMECONTROLLER, "GameController"},
    {tagsTypes.CELL, "Cell"},
  };
  public static string GetTagName(tagsTypes tag) => _tags[tag];
}
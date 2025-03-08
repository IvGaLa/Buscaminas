using System.Collections.Generic;
public class TagsVariables
{
  static readonly Dictionary<TagsTypes, string> _tags = new(){
    {TagsTypes.UNTAGGED, "Untagged"},
    {TagsTypes.RESPAWN, "Respawn"},
    {TagsTypes.FINISH, "Finish"},
    {TagsTypes.EDITORONLY, "EditorOnly"},
    {TagsTypes.MAINCAMERA, "MainCamera"},
    {TagsTypes.PLAYER, "Player"},
    {TagsTypes.GAMECONTROLLER, "GameController"},
    {TagsTypes.CELL, "Cell"},
  };
  public static string GetTagName(TagsTypes tag) => _tags[tag];
}
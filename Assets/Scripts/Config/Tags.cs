using System.Collections.Generic;

public static class Tags
{
  public static Dictionary<tagsTypes, string> GetTagName()
  {
    Dictionary<tagsTypes, string> _tags = new(){
    {tagsTypes.UNTAGGED, "Untagged"},
    {tagsTypes.RESPAWN, "Respawn"},
    {tagsTypes.FINISH, "Finish"},
    {tagsTypes.EDITORONLY, "EditorOnly"},
    {tagsTypes.MAINCAMERA, "MainCamera"},
    {tagsTypes.PLAYER, "Player"},
    {tagsTypes.GAMECONTROLLER, "GameController"},
    {tagsTypes.CELL, "Cell"},
  };
    return _tags;
  }

}
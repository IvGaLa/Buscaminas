using System.Collections.Generic;

public class TextVariables
{

  static readonly Dictionary<TextTypes, string> _text = new(){
    {TextTypes.LOSE_GAME, "You Lose"},
    {TextTypes.WIN_GAME, "You Win"},
  };

  static readonly Dictionary<TextTypes, string> _name = new(){
    {TextTypes.LOSE_GAME, "LoseText"},
    {TextTypes.WIN_GAME, "WinText"},
  };

  public static string GetText(TextTypes text) => _text[text];
  public static string GetName(TextTypes text) => _name[text];

}
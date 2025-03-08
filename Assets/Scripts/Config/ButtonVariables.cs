using System.Collections.Generic;

public class ButtonVariables
{
  // Defining buttons text
  static readonly Dictionary<ButtonTypes, string> _buttonText = new(){
    {ButtonTypes.BACK, "Main menu"},
    {ButtonTypes.REPEAT, "Play again"},
  };

  // Defining buttons name in hierarchy list
  static readonly Dictionary<ButtonTypes, string> _buttonName = new(){
    {ButtonTypes.BACK,"BackButton"},
    {ButtonTypes.REPEAT,"RepeatButton"},
  };

  public static string GetButtonText(ButtonTypes text) => _buttonText[text];
  public static string GetButtonName(ButtonTypes name) => _buttonName[name];
}
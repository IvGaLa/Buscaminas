using System.Collections.Generic;
using UnityEngine;

public class MusicVariables
{
  static readonly Dictionary<MusicTypes, AudioClip> _music = new()
  {
    {MusicTypes.MUSIC01, Resources.Load<AudioClip>($"{ConfigVariables.GetConfigValue<string>(ConfigTypes.MUSIC_PATH)}/Music01")}
  };

  public static AudioClip GetMusic(MusicTypes music) => _music[music];
}
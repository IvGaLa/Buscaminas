using System.Collections.Generic;
using UnityEngine;

public class MusicVariables
{

  readonly static string _musicPath = ConfigVariables.GetConfigValue<string>(ConfigTypes.MUSIC_PATH);

  static readonly Dictionary<MusicTypes, AudioClip> _music = new()
  {
    {MusicTypes.MUSIC01, LoadMusicResource("Music01")},
  };

  static AudioClip LoadMusicResource(string _audioClip) => Resources.Load<AudioClip>($"{_musicPath}{_audioClip}");

  public static AudioClip GetMusic(MusicTypes music) => _music[music];
}
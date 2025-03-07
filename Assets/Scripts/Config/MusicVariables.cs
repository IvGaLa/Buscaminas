using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;

public class MusicVariables
{
  static readonly string musicPath = ConfigVariables.GetConfigValue<string>(ConfigTypes.MUSIC_PATH);
  static readonly Dictionary<MusicTypes, AudioClip> _music = new()
  {
    {MusicTypes.MUSIC01, LoadMusicResource("Music01")},
  };

  static AudioClip LoadMusicResource(string _audioClip) => Resources.Load<AudioClip>($"{musicPath}{_audioClip}");

  public static AudioClip GetMusic(MusicTypes music) => _music[music];
}
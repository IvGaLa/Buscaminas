using System.Collections.Generic;
using UnityEngine;

public class SFXVariables
{
  static readonly string sfxPath = ConfigVariables.GetConfigValue<string>(ConfigTypes.SFX_PATH);
  static readonly Dictionary<SFXTypes, AudioClip> _sfx = new()
  {
    {SFXTypes.CLICKBUTTON, LoadSFXResource("ClickButton")},
    {SFXTypes.EXPLOSION01, LoadSFXResource("Explosion01")},
    {SFXTypes.REVEALCELL, LoadSFXResource("RevealCell")},
    {SFXTypes.SELECTGAME, LoadSFXResource("SelectGame")},
    {SFXTypes.WINGAME, LoadSFXResource("WinGame")},
  };
  static AudioClip LoadSFXResource(string _audioClip) => Resources.Load<AudioClip>($"{sfxPath}{_audioClip}");
  public static AudioClip GetSFX(SFXTypes music) => _sfx[music];
}
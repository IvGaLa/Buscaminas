using System.Collections.Generic;
using UnityEngine;

public class SFXVariables
{
  static readonly Dictionary<SFXTypes, AudioClip> _sfx = new()
  {
    {SFXTypes.EXPLOSION01, Resources.Load<AudioClip>($"{ConfigVariables.GetConfigValue<string>(ConfigTypes.SFX_PATH)}Explosion01")},
    {SFXTypes.WINGAME, Resources.Load<AudioClip>($"{ConfigVariables.GetConfigValue<string>(ConfigTypes.SFX_PATH)}WinGame")},
  };

  public static AudioClip GetSFX(SFXTypes music) => _sfx[music];
}
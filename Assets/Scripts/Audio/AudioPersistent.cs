using UnityEngine;
public class AudioPersistent : MonoBehaviour
{
  // With this script added to the sounds prefab (SFXPlayer, MusicPlayer) I get the audio to play when clicking even if the scene changes.
  void Awake() => DontDestroyOnLoad(gameObject);
}
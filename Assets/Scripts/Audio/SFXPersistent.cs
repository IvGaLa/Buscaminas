using UnityEngine;
public class SFXPersistent : MonoBehaviour
{
  // With this script added to the sounds prefab (SFXPlayer) I get the audio to play when clicking even if the scene changes.
  void Awake() => DontDestroyOnLoad(gameObject);
}
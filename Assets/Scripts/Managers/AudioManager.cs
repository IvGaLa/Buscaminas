using UnityEngine;

public class AudioManager : MonoBehaviour
{
  public static AudioManager Instance { get; private set; }
  AudioSource sfxAudioSource;

  void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
      sfxAudioSource = Resources.Load<GameObject>(ConfigVariables.GetConfigValue<string>(ConfigTypes.PREFABS_PATH) + ConfigVariables.GetConfigValue<string>(ConfigTypes.PREFAB_SFX_AUDIO_SOURCE)).GetComponent<AudioSource>();
      DontDestroyOnLoad(gameObject); // Mantenemos el Manager en todas las escenas
    }
    else
    {
      Destroy(gameObject);
    }
  }

  public void PlayMusic()
  {

  }

  public void PlaySFX(SFXTypes sfxType, Transform spawnTransform, float volume = 1f)
  {
    // Spawn gameObject with audiolistener
    AudioSource audioSource = Instantiate(sfxAudioSource, spawnTransform.position, Quaternion.identity);

    // Assign audio clip
    audioSource.clip = SFXVariables.GetSFX(sfxType);

    // Assign volume
    audioSource.volume = volume;

    // Play sound
    audioSource.Play();

    // Get audio length
    float clipLength = audioSource.clip.length;

    // Destroy gameobject after playing
    Destroy(audioSource.gameObject, clipLength);
  }
}

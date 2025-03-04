using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DifficultyButton : MonoBehaviour
{
    [SerializeField] ButtonData _gameSettings; // ScriptableObject con la configuración de dificultad

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(SelectDifficulty);
        GetComponentInChildren<TMP_Text>().text = GameSettings.GetGameSettings(_gameSettings.GameSetting).Name;
    }

    void SelectDifficulty()
    {
        AudioManager.Instance.PlaySFX(SFXTypes.SELECTGAME);
        ConfigVariables.SetConfigValue(ConfigTypes.DIFFICULTY, _gameSettings.GameSetting);
        SceneManager.LoadScene(ScenesVariables.GetScenesVariables(ScenesTypes.GAME));
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DifficultyButton : MonoBehaviour
{
    [SerializeField] private ButtonData _gameSettings; // ScriptableObject con la configuración de dificultad
    private Button _button;
    private TMP_Text _buttonText;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _buttonText = GetComponentInChildren<TMP_Text>();
    }

    private void Start()
    {
        _button.onClick.AddListener(SelectDifficulty);
        _buttonText.text = GameSettings.GetGameSettings(_gameSettings.GameSetting).Name;
    }

    private void SelectDifficulty()
    {
        ConfigVariables.SetConfigValue(configTypes.DIFFICULTY, _gameSettings.GameSetting);
        SceneManager.LoadScene(ScenesVariables.GetScenesVariables()[scenesTypes.GAME]);
    }
}
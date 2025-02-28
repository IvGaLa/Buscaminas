using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    //Button _button;
    [SerializeField] gameSettingsTypes _gameSettings; // Set difficulty in inspector for each button


    void Start() => GetComponent<Button>().onClick.AddListener(() => SelectDifficulty(_gameSettings));

    void SelectDifficulty(gameSettingsTypes gameSettings = gameSettingsTypes.EASY)
    {
        ConfigVariables.SetConfigValue<gameSettingsTypes>(configTypes.DIFFICULTY, gameSettings);
        SceneManager.LoadScene(ScenesVariables.GetScenesVariables()[scenesTypes.GAME]);
    }
}

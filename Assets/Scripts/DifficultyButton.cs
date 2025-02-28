using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyButton : MonoBehaviour
{
    readonly gameSettingsTypes[] difficulties = { gameSettingsTypes.EASY, gameSettingsTypes.MEDIUM, gameSettingsTypes.HARD };

    public void SelectDifficulty(int difficulty)
    {
        ConfigVariables.SetConfigValue<gameSettingsTypes>(configTypes.DIFFICULTY, difficulties[difficulty]);
        SceneManager.LoadScene(ScenesVariables.GetScenesVariables()[scenesTypes.GAME]);
    }
}

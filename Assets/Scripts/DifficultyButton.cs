using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyButton : MonoBehaviour
{
    readonly difficultyTypes[] difficulties = { difficultyTypes.EASY, difficultyTypes.MEDIUM, difficultyTypes.HARD };

    public void SelectDifficulty(int difficulty)
    {
        ConfigVariables.SetConfigValue<difficultyTypes>(configTypes.DIFFICULTY, difficulties[difficulty]);
        SceneManager.LoadScene(ScenesVariables.GetScenesVariables()[scenesTypes.GAME]);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    void Start() => GetComponent<Button>().onClick.AddListener(BackToMain);
    void BackToMain() => SceneManager.LoadScene(ScenesVariables.GetScenesVariables(ScenesTypes.MAIN));
}
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    void Start() => GetComponent<Button>().onClick.AddListener(BackToMain);
    void BackToMain()
    {
        AudioManager.Instance.PlaySFX(SFXTypes.CLICKBUTTON);
        SceneManager.LoadScene(ScenesVariables.GetScenesVariables(ScenesTypes.MAIN));
    }
}
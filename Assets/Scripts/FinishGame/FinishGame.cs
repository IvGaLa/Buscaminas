using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class FinishGame : MonoBehaviour
{
    TMP_Text winTextName, loseTextName;

    void Awake()
    {
        SetButton(ButtonTypes.REPEAT, RepeatGame);
        SetButton(ButtonTypes.BACK, BackToMain);

        winTextName = GetText(TextTypes.WIN_GAME);
        loseTextName = GetText(TextTypes.LOSE_GAME);
    }

    public void ShowPanel(bool winGame)
    {
        winTextName.gameObject.SetActive(winGame);
        loseTextName.gameObject.SetActive(!winGame);
    }

    void SetButton(ButtonTypes buttonType, UnityEngine.Events.UnityAction action)
    {
        Button button;
        string name = ButtonVariables.GetButtonName(buttonType);
        button = transform.Find(name)?.GetComponent<Button>();
        button.onClick.AddListener(action);
        button.GetComponentInChildren<TMP_Text>().text = ButtonVariables.GetButtonText(buttonType);
    }

    TMP_Text GetText(TextTypes textType)
    {
        TMP_Text text;
        text = transform.Find(TextVariables.GetName(textType))?.GetComponent<TMP_Text>();
        text.text = TextVariables.GetText(textType);
        text.gameObject.SetActive(false);
        return text;
    }


    void RepeatGame()
    {
        gameObject.SetActive(false);
        GameManager.Instance.StartGame();
    }

    void BackToMain()
    {
        AudioManager.Instance.PlaySFX(SFXTypes.CLICKBUTTON);
        SceneManager.LoadScene(ScenesVariables.GetScenesVariables(ScenesTypes.MAIN));
    }
}

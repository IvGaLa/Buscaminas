using TMPro;
using UnityEngine;

public class TimerGame : MonoBehaviour
{
    static float timer = 0;
    TMP_Text timerText;

    void Awake() => timerText = GetComponentInChildren<TMP_Text>();
    void Update()
    {
        if (!GameManager.Instance.Playing) return;

        timer += Time.deltaTime;
        timerText.text = TimerToString();
    }
    string TimerToString() => $"{(int)(timer / 60f):D2}:{(int)(timer % 60f):D2}"; // Con el :D2 forzamos que aparezcan siempre dos dígitos en el minutero y secundero
    public static float Timer { get { return timer; } set { timer = value; } }
}

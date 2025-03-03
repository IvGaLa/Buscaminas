using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    static float timer = 0;
    TMP_Text timerText;

    void Awake() => timerText = GetComponentInChildren<TMP_Text>();
    string TimerToString() => $"{(int)(timer / 60f):D2}:{(int)(timer % 60f):D2}"; // Con el :D2 forzamos que aparezcan siempre dos dígitos en el minutero y secundero
    void Update()
    {
        if (!GameManager.Instance.Playing) return;

        timer += Time.deltaTime;
        timerText.text = TimerToString();
    }

    public static void ResetTimer() => timer = 0;

}

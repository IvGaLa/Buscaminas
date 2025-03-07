using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    static TMP_Text counterText;
    void Awake() => counterText = GetComponentInChildren<TMP_Text>();
    public static void SetCounter(int count) => counterText.text = count.ToString();
}

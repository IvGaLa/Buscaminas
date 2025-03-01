using UnityEngine;

[CreateAssetMenu(fileName = "New Difficulty button", menuName = "Difficulty button")]
public class ButtonData : ScriptableObject
{
    [SerializeField] gameSettingsTypes _gameSetting;
    public gameSettingsTypes GameSetting => _gameSetting;
}
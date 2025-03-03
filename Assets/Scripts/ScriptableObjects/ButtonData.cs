using UnityEngine;

[CreateAssetMenu(fileName = "New Difficulty button", menuName = "Difficulty button")]
public class ButtonData : ScriptableObject
{
    [SerializeField] GameSettingsTypes _gameSetting;
    public GameSettingsTypes GameSetting => _gameSetting;
}
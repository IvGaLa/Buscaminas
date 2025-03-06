using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class RankingManager : MonoBehaviour
{
  string rankingFile;
  Dictionary<GameSettingsTypes, List<Ranking>> rankings;

  public static RankingManager Instance { get; private set; }

  void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
      DontDestroyOnLoad(gameObject); // Mantener el Manager en todas las escenas
    }
    else
    {
      Destroy(gameObject); // Destruir el objeto si ya existe
    }
  }

  void Start()
  {
    rankingFile = ConfigVariables.GetConfigValue<string>(ConfigTypes.RANKING_PATH);
    ParseRankings();
  }

  void ParseRankings()
  {
    rankings = new Dictionary<GameSettingsTypes, List<Ranking>>();
    if (File.Exists(rankingFile))
    {
      string json = File.ReadAllText(rankingFile);
      RankingList rankingJSON = JsonUtility.FromJson<RankingList>(json);
      rankings.Add(GameSettingsTypes.EASY, rankingJSON.EASY);
      rankings.Add(GameSettingsTypes.MEDIUM, rankingJSON.MEDIUM);
      rankings.Add(GameSettingsTypes.HARD, rankingJSON.HARD);
    }
    else
    {
      rankings.Add(GameSettingsTypes.EASY, new List<Ranking>());
      rankings.Add(GameSettingsTypes.MEDIUM, new List<Ranking>());
      rankings.Add(GameSettingsTypes.HARD, new List<Ranking>());
      SaveRanking();
    }
  }

  public void GetRankings()
  {
    GameSettingsTypes difficulty = ConfigVariables.GetConfigValue<GameSettingsTypes>(ConfigTypes.DIFFICULTY);
    if (rankings.TryGetValue(difficulty, out List<Ranking> rankingList))
      foreach (Ranking ranking in rankingList)
        Debug.Log($"Time: {ranking.time} - Date: {ranking.date}");
  }


  public void AddRanking()
  {
    GameSettingsTypes difficulty = ConfigVariables.GetConfigValue<GameSettingsTypes>(ConfigTypes.DIFFICULTY);

    if (!rankings.ContainsKey(difficulty))
      rankings[difficulty] = new List<Ranking>();

    Ranking newEntry = new(TimerGame.Timer);
    rankings[difficulty].Add(newEntry);
    SaveRanking();
  }

  void SaveRanking()
  {
    RankingList updatedRanking = new()
    {
      EASY = rankings[GameSettingsTypes.EASY],
      MEDIUM = rankings[GameSettingsTypes.MEDIUM],
      HARD = rankings[GameSettingsTypes.HARD]
    };
    string json = JsonUtility.ToJson(updatedRanking, true);
    File.WriteAllText(rankingFile, json);
    Debug.Log("Ranking saved");
  }
}

using System.Collections.Generic;

[System.Serializable]
public class RankingList
{
  public List<Ranking> EASY = new();
  public List<Ranking> MEDIUM = new();
  public List<Ranking> HARD = new();
}
[System.Serializable]
public class Ranking
{
  public string time;
  public string date;
  public Ranking(float _time)
  {
    this.date = System.DateTime.Now.ToString(ConfigVariables.GetConfigValue<string>(ConfigTypes.DATE_FORMAT));
    this.time = _time.ToString();
  }
}
public class GameSettingValue
{
  public object Value { get; }
  public GameSettingValue(object value) => Value = value;
  public T GetValue<T>() => Value is T typedValue ? typedValue : default!;
}
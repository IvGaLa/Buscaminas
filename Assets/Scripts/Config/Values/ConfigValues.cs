public class ConfigValues<T>
{
  public T Value { get; private set; }
  public ConfigValues(T value) => Value = value;
  public void SetValue(T newValue) => Value = newValue;
}
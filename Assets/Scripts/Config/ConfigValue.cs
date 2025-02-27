public class ConfigValue<T>
{
  public T Value { get; private set; }
  public ConfigValue(T value) => Value = value;
  public void SetValue(T newValue) => Value = newValue;
}
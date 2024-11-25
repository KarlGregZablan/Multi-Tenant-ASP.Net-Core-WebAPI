namespace BoilerplateAPI.Infrastructure
{
  public class InitializeOnStartupAttribute : Attribute
  {
    public object InitialValue { get; set; }

    public InitializeOnStartupAttribute(object initialValue)
    {
      InitialValue = initialValue;
    }
  }
}

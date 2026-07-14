using NorthWaveConsole.Enums;

namespace NorthWaveConsole.Models
{
  public class Customer : BaseEntity
  {
    public string Name { get; }
    public CustomerType Type { get; }

    public Customer(int id, string name, CustomerType type)
    {
      Id = id;
      Name = name;
      Type = type;
    }
  }
}
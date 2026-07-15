using NorthWaveConsole.Models;

namespace NorthWaveConsole.Repository
{
  public class FileContext
  {
    public List<Order> PendingOrders { get; } = new(); 
  }
}
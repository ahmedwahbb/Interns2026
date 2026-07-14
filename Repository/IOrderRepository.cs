using NorthWaveConsole.Models;

namespace NorthWaveConsole.Repository
{
  public interface IOrderRepository
  {
    void Save(Order order);
  }
}
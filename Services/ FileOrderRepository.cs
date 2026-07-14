using NorthWaveConsole.Models;
using NorthWaveConsole.Repository;

namespace NorthWaveConsole.Services
{
  public class FileOrderRepository : IOrderRepository
  {
    public void Save(Order order)
    {
      File.AppendAllText("orders.txt",
        $"{order.Id}," + $"{order.CustomerName}," + $"{order.CustomerType}," + $"{order.Total}," + $"{order.Status}" + $"{Environment.NewLine}");
    }
  }
}
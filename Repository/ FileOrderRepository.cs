using NorthWaveConsole.Models;
using NorthWaveConsole.Repository;

namespace NorthWaveConsole.Repository
{
  public class FileOrderRepository : IOrderRepository
  {
    public void Save(Order order)
    {
      File.AppendAllText("orders.txt",
        $"{order.Id}," + $"{order.Customer.Name}," + $"{order.Customer.Type}," + $"{order.Total}," + $"{order.Status}" + $"{Environment.NewLine}");
    }
  }
}
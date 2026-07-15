using NorthWaveConsole.Models;
using NorthWaveConsole.Repository;

namespace NorthWaveConsole.Repository
{
  public class FileOrderRepository : IOrderRepository
  {
    private readonly FileContext _context;
    public FileOrderRepository(FileContext context)
    {
      _context = context;
    }
    public void Add(Order order)
    {
      _context.PendingOrders.Add(order);
    }
  }
}
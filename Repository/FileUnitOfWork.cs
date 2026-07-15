namespace NorthWaveConsole.Repository
{
  public class FileUnitOfWork : IUnitOfWork
  {
    private readonly FileContext _context;
    public FileUnitOfWork(FileContext context)
    {
      _context = context;
    }
    public void Commit()
    {
      foreach (var order in _context.PendingOrders)
      {
        File.AppendAllText("orders.txt", $"{order.Id}," + $"{order.Customer.Name}," + $"{order.Customer.Type}," + $"{order.Total}," + $"{order.Status}" + $"{Environment.NewLine}");
      }

      _context.PendingOrders.Clear();
    }
  }
}

using NorthWaveConsole.Models;

namespace NorthWaveConsole.Services
{
  public class OrderValidator
  {
    public bool IsValid(Order order)
    {
      if (order == null)
        return false;

      if (string.IsNullOrWhiteSpace(order.CustomerName))
        return false;

      if (order.Items.Count == 0)
        return false;

      return true;
    }
  }
}
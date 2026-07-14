using NorthWaveConsole.Enums;
using NorthWaveConsole.Models;

namespace NorthWaveConsole.Services
{
  public class OrderPricingService
  {
    public decimal CalculateTotal(Order order)
    {
      decimal total = order.Subtotal;

      switch (order.CustomerType)
      {
        case CustomerType.VIP:
          total *= 0.8m;
          break;

        case CustomerType.Wholesale:
          total *= 0.85m;
          break;

        case CustomerType.Employee:
          total *= 0.5m;
          break;
      }

      return total;
    }
  }
}
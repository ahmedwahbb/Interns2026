using NorthWaveConsole.Models;
using NorthWaveConsole.Repository;

namespace NorthWaveConsole.Services
{
  public class EmailNotificationService : INotificationService
  {
    public void SendOrderConfirmation(Order order)
    {
      Console.WriteLine($"[EMAIL] To: {order.CustomerName} - " + $"Your order #{order.Id} totalling {order.Total:C} was received.");
    }
  }
}
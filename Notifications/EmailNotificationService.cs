using NorthWaveConsole.Models;
using NorthWaveConsole.Repository;

namespace NorthWaveConsole.Notifications
{
  public class EmailNotificationService : INotificationService
  {
    public void SendOrderConfirmation(Order order)
    {
      Console.WriteLine($"[EMAIL] To: {order.Customer.Name} - " + $"Your order #{order.Id} totalling {order.Total:C} was received.");
    }
  }
}
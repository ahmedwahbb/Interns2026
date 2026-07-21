using NorthWaveConsole.Application.Interfaces;
using NorthWaveConsole.Domain.Entities;

namespace NorthWaveConsole.Infrastructure.Services
{
    public class NotifyOrder : INotificationService
    {
        public void Notify(Order order)
        {
            
            System.Console.WriteLine($"[Notification] Order #{order.Id} for {order.CustomerName} " +
                                      $"is now '{order.Status}'. Total: {order.Total:C}");
        }
    }
}

using NorthWaveConsole.Models;
using NorthWaveConsole.Repositories;
using System;

namespace NorthWaveConsole.Services
{
    public class NotifyOrder : IOrderNotifier
    {
        public void Notify(Order order)
        {
            Console.WriteLine($"[Notification] Order #{order.Id} for {order.Customer.Name} " +
                               $"is now '{order.Status}'. Total: {order.Total:C}");
        }
    }
}

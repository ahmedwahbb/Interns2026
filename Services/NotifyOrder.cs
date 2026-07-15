using System;
using NorthWaveConsole.Models;

namespace NorthWaveConsole.Services
{
    public class NotifyOrder
    {
        public void Notify(Order order)
        {
            Console.WriteLine($"[Notification] Order #{order.Id} for {order.CustomerName} " +
                               $"is now '{order.Status}'. Total: {order.Total:C}");
        }
    }
}

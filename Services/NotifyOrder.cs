using NorthWaveConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWaveConsole.Services
{
    public class NotifyOrder
    {

        public void SendOrderConfirmation(Order order)
        {
            Console.WriteLine($"[EMAIL] To: {order.CustomerName} - " + $"Your order #{order.Id} totalling {order.Total:C} was received.");
        }


    } 
}

using System;
using NorthWaveConsole.Models;
using NorthWaveConsole.Services;

namespace NorthWaveConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new OrderService();

            var order1 = new Order
            {
                CustomerName = "Ahmed Fathy",
                CustomerType = "VIP",
                Items = new System.Collections.Generic.List<OrderItem>
                {
                    new OrderItem { ProductName = "Server Rack Unit", Price = 450.00m, Qty = 2 },
                    new OrderItem { ProductName = "Network Switch",   Price = 120.00m, Qty = 1 },
                }
            };

            var order2 = new Order
            {
                CustomerName = "",
                CustomerType = "Wholesale",
                Items = new System.Collections.Generic.List<OrderItem>()
            };

            bool order1Ok = service.ProcessOrder(order1);
            bool order2Ok = service.ProcessOrder(order2);

            // Now you know immediately, right here, without opening OrderService.cs:
            Console.WriteLine(order1Ok
                ? $"Order 1: SUCCESS (Id={order1.Id}, Total={order1.Total:C})"
                : $"Order 1: FAILED - {order1.FailureReason}");

            Console.WriteLine(order2Ok
                ? $"Order 2: SUCCESS (Id={order2.Id}, Total={order2.Total:C})"
                : $"Order 2: FAILED - {order2.FailureReason}");

            Console.WriteLine("Done. Check orders.txt and app.log in the output folder.");
        }
    }
}

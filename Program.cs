using System;
using NorthWaveConsole.Models;
using NorthWaveConsole.Services;

namespace NorthWaveConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Everything is wired up by hand, right here, with 'new'.
            // There is no composition root, no DI container, and no way
            // to substitute a fake OrderService in a test.
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
                CustomerName = "",   // deliberately invalid - watch what happens
                CustomerType = "Wholesale",
                Items = new System.Collections.Generic.List<OrderItem>()
            };

            service.ProcessOrder(order1);
            service.ProcessOrder(order2); // silently does nothing - no error, no explanation

            Console.WriteLine("Done. Check orders.txt and app.log in the output folder.");
            Console.WriteLine("Ask yourself: how would YOU know order2 failed, right now, without reading this source code?");
        }
    }
}

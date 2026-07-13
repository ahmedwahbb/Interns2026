using System;
using NorthWaveConsole.Enum;
using NorthWaveConsole.Models;
using NorthWaveConsole.Services;

namespace NorthWaveConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var validator = new Validation();
            var pricingService = new PricingOrder();
            SaveOrder repository = new SaveOrder();
            NotifyOrder notificationService = new NotifyOrder();
            LoggerOrder logger = new LoggerOrder();

            var service = new OrderService(validator, pricingService, repository, notificationService, logger);

            var order1 = new Order("Khaled Yasser", Layer.Normal);

            order1.AddItem(new OrderItem("Server Rack Unit", 450.00m, 7));

            order1.AddItem(new OrderItem("Laptop", 70.00m, 2));
            /////////////
            var order2 = new Order("", Layer.Employee);

            service.ProcessOrder(order1);
            service.ProcessOrder(order2);
            Console.WriteLine("Done. Check orders.txt and app.log in the output folder.");
            Console.WriteLine("Ask yourself: how would YOU know order2 failed, right now, without reading this source code?");
        }
    }
}

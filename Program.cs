using System;
using NorthWaveConsole.Enum;
using NorthWaveConsole.Models;
using NorthWaveConsole.Repositories;
using NorthWaveConsole.Services;

namespace NorthWaveConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var idGenerator = new OrderIdGenerator();
            IOrderValidator validator = new Validation();
            IOrderPricingService pricingService = new PricingOrder();
            IOrderRepository repository = new FileOrderRepository();
            IOrderNotifier notificationService = new NotifyOrder();
            IOrderLogger logger = new LoggerOrder();

            var service = new OrderService(validator, pricingService, repository, notificationService, logger);

            var customer1 = new Customer("Khaled Yasser", Layer.Normal);
            var order1 = new Order(idGenerator.Next(), customer1);
            order1.AddItem(new OrderItem("Server Rack Unit", 450.00m, 7));
            order1.AddItem(new OrderItem("Laptop", 70.00m, 2));

            var customer2 = new Customer("", Layer.Employee);
            var order2 = new Order(idGenerator.Next(), customer2);

            service.ProcessOrder(order1);
            service.ProcessOrder(order2);

            Console.WriteLine("Done. Check orders.txt and app.log in the output folder.");
            Console.WriteLine("Ask yourself: how would YOU know order2 failed, right now, without reading this source code?");
        }
    }
}

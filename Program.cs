using NorthWaveConsole.Models;
using NorthWaveConsole.Services;
using NorthWaveConsole.Services.Discounts;
using NorthWaveConsole.Services.FileLogger;
using NorthWaveConsole.Services.FileOrderRepository;
using NorthWaveConsole.Services.Notifier;

namespace NorthWaveConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new FileRepository();
            var notification = new NotifierService();
            var logger = new FileLoggerService();
            var discountFactory = new DiscountStrategyFactory();

            var service = new OrderService(
                repository,
                logger,
                notification,
                discountFactory
            );


            var order1 = new Order
            (
                customerName: "Ahmed Fathy",
                customerType: CustomerType.VIP
            );
            order1.AddItem(new OrderItem(productName: "Server Rack Unit", price: 450.00m, quantity: 2));
            order1.AddItem(new OrderItem(productName: "Network Switch", price: 120.00m, quantity: 1));
            
            var order2 = new Order(
                customerName: "Mohamed Saeed",
                customerType: CustomerType.Wholesale
            );
            order2.AddItem(new OrderItem(productName: "Router", price: 200.00m, quantity: 1));


            bool order1Ok = service.ProcessOrder(order1);
            if (!order1Ok)
                Console.WriteLine("Order 1 failed");
            bool order2Ok = service.ProcessOrder(order2);
            if (!order2Ok)
                Console.WriteLine("Order 2 failed");
        }
    }
}

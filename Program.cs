using NorthWaveConsole.Enums;
using NorthWaveConsole.Models;
using NorthWaveConsole.Repository;
using NorthWaveConsole.Services;

namespace NorthWaveConsole
{
  class Program
  {
    static void Main(string[] args)
    {
      var validator = new OrderValidator();
      var pricingService = new OrderPricingService();
      IOrderRepository repository = new FileOrderRepository();
      INotificationService notificationService = new EmailNotificationService();
      ILogger logger = new FileLogger();
    
      var service = new OrderService(validator, pricingService, repository, notificationService, logger);

      var order1 = new Order("Ahmed Fathy", CustomerType.VIP);
      
      order1.AddItem(new OrderItem("Server Rack Unit", 450.00m, 2));

      order1.AddItem(new OrderItem("Network Switch", 120.00m, 1));

      var order2 = new Order("", CustomerType.Wholesale);

      service.ProcessOrder(order1);
      service.ProcessOrder(order2); 
      Console.WriteLine("Done. Check orders.txt and app.log in the output folder.");
      Console.WriteLine("Ask yourself: how would YOU know order2 failed, right now, without reading this source code?");
    }
  }
}

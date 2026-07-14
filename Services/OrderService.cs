using NorthWaveConsole.Enums;
using NorthWaveConsole.Logging;
using NorthWaveConsole.Models;
using NorthWaveConsole.Notifications;
using NorthWaveConsole.Repository;

namespace NorthWaveConsole.Services
{
   
  public class OrderService
  {
    private static int _nextId = 1;
    private readonly OrderValidator _validator;
    private readonly OrderPricingService _pricingService;
    private readonly IOrderRepository _repository;
    private readonly INotificationService _notificationService;
    private readonly IAppLogger _logger;
    public OrderService(OrderValidator validator, OrderPricingService pricingService, IOrderRepository repository, INotificationService notificationService,  IAppLogger logger)
    {
      _validator = validator;
      _pricingService = pricingService;
      _repository = repository;
      _notificationService = notificationService;
      _logger = logger;
    }

    public void ProcessOrder(Order order)
    {
      var validationResult = _validator.Validate(order);
      if (!validationResult.IsValid)
      {
        _logger.Log(validationResult.ErrorMessage);
        return;
      }
          
      order.SetId(_nextId++);
      order.SetStatus(OrderStatus.New);
      decimal total = _pricingService.CalculateTotal(order);
      order.SetTotal(total);

      try
      {
        _repository.Save(order);
        _notificationService.SendOrderConfirmation(order);
        _logger.Log("Order processed: " + order.Id);
      }
      catch (Exception ex)
      {
        _logger.Log($"Failed to process order {order.Id}: {ex}");
      }   
    }
  }
}

using NorthWaveConsole.Enums;
using NorthWaveConsole.Models;
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
    private readonly ILogger _logger;
    public OrderService(OrderValidator validator, OrderPricingService pricingService, IOrderRepository repository, INotificationService notificationService,  ILogger logger)
    {
      _validator = validator;
      _pricingService = pricingService;
      _repository = repository;
      _notificationService = notificationService;
      _logger = logger;
    }

    public void ProcessOrder(Order o)
    {
      if (!_validator.IsValid(o))
        return;
          
      o.SetId(_nextId++);
      o.SetStatus(OrderStatus.New);
      decimal total = _pricingService.CalculateTotal(o);
      o.SetTotal(total);

      try
      {
        _repository.Save(o);
        _notificationService.SendOrderConfirmation(o);
        _logger.Log("Order processed: " + o.Id);
      }
      catch (Exception)
      {              
      }   
    }
  }
}

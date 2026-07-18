using NorthWaveConsole.Models;
using NorthWaveConsole.Repositories;

namespace NorthWaveConsole.Services
{
    public class OrderService
    {
        private readonly IOrderValidator _validator;
        private readonly IOrderPricingService _pricingService;
        private readonly IOrderRepository _repository;
        private readonly IOrderNotifier _notificationService;
        private readonly IOrderLogger _logger;

        public OrderService(
            IOrderValidator validator,
            IOrderPricingService pricingService,
            IOrderRepository repository,
            IOrderNotifier notificationService,
            IOrderLogger logger)
        {
            _validator = validator;
            _pricingService = pricingService;
            _repository = repository;
            _notificationService = notificationService;
            _logger = logger;
        }

        public void ProcessOrder(Order order)
        {
            if (!_validator.IsValid(order, out string reason))
            {
                order.MarkFailed(reason);
                _logger.LogError(order, reason);
                return;
            }

            order.MarkValidated();

            decimal total = _pricingService.CalculateTotal(order);
            order.SetTotal(total);

            _repository.Save(order);
            order.MarkSaved();

            _notificationService.Notify(order);
            order.MarkNotified();

            order.MarkCompleted();
            _logger.Log(order, "Order processed successfully.");
        }
    }
}

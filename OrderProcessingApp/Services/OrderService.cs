using NorthWaveConsole.Models;

namespace NorthWaveConsole.Services
{
    public class OrderService
    {
        private readonly Validation _validator;
        private readonly PricingOrder _pricingService;
        private readonly SaveOrder _repository;
        private readonly NotifyOrder _notificationService;
        private readonly LoggerOrder _logger;

        public OrderService(
            Validation validator,
            PricingOrder pricingService,
            SaveOrder repository,
            NotifyOrder notificationService,
            LoggerOrder logger)
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

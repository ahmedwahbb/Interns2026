using System;
using System.IO;
using NorthWaveConsole.Enum;
using NorthWaveConsole.Models;

namespace NorthWaveConsole.Services
{

    public class OrderService
    {
        private static int _nextId = 1;
        private readonly Validation _validator;
        private readonly PricingOrder _pricingService;
        private readonly SaveOrder _repository;
        private readonly NotifyOrder _notificationService;
        private readonly LoggerOrder _logger;
        public OrderService(Validation validator, PricingOrder pricingService, SaveOrder repository, NotifyOrder notificationService, LoggerOrder logger)
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
            o.SetStatus(Status.New);
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

using NorthWaveConsole.Interfaces;
using NorthWaveConsole.Models;

namespace NorthWaveConsole.Services
{
    public class OrderService
    {
        private readonly IValidator _validator;
        private readonly IPricingService _pricingService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationService _notificationService;
        private readonly IOrderLogger _logger;

        public OrderService(
            IValidator validator,
            IPricingService pricingService,
            IUnitOfWork unitOfWork,
            INotificationService notificationService,
            IOrderLogger logger)
        {
            _validator = validator;
            _pricingService = pricingService;
            _unitOfWork = unitOfWork;
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

            // مش بنحفظ فورًا، بس بنضيف الـ order للـ Unit of Work
            _unitOfWork.Orders.Add(order);
            order.MarkSaved();

            _notificationService.Notify(order);
            order.MarkNotified();

            order.MarkCompleted();
            _logger.Log(order, "Order processed successfully.");
        }

        // بتعمل commit لكل الـ orders اللي اتضافت للـ Unit of Work مرة واحدة
        public int CommitOrders()
        {
            return _unitOfWork.Complete();
        }
    }
}

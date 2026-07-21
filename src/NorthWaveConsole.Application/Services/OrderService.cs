using NorthWaveConsole.Application.DTOs;
using NorthWaveConsole.Application.Interfaces;
using NorthWaveConsole.Domain.Entities;

namespace NorthWaveConsole.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IPricingService _pricingService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationService _notificationService;
        private readonly IOrderLogger _logger;

        public OrderService(
            IPricingService pricingService,
            IUnitOfWork unitOfWork,
            INotificationService notificationService,
            IOrderLogger logger)
        {
            _pricingService = pricingService;
            _unitOfWork = unitOfWork;
            _notificationService = notificationService;
            _logger = logger;
        }

        // ملحوظة: التحقق من صحة الـ input بقى مسؤولية FluentValidation عند الـ Controller
        // (CreateOrderRequestValidator)، فالـ request اللي بيوصل هنا مضمون إنه valid شكليًا.
        public OrderResult ProcessOrder(CreateOrderRequest request)
        {
            var order = new Order(request.CustomerName, request.CustomerType);

            foreach (var item in request.Items)
            {
                order.AddItem(new OrderItem(item.ProductName, item.Price, item.Qty));
            }

            order.MarkValidated();

            decimal total = _pricingService.CalculateTotal(order);
            order.SetTotal(total);

            
            _unitOfWork.Orders.Add(order);
            order.MarkSaved();

            _notificationService.Notify(order);
            order.MarkNotified();

            order.MarkCompleted();
            _logger.Log(order, "Order processed successfully.");

            return MapToResult(order);
        }

        public OrderResult GetById(int id)
        {
            var order = _unitOfWork.Orders.GetById(id);
            return order is null ? null : MapToResult(order);
        }

        
        public int CommitOrders()
        {
            return _unitOfWork.Complete();
        }

        private static OrderResult MapToResult(Order order) => new()
        {
            OrderId = order.Id,
            CustomerName = order.CustomerName,
            CustomerType = order.CustomerType,
            Status = order.Status,
            Subtotal = order.Subtotal,
            Total = order.Total,
            FailureReason = order.FailureReason
        };
    }
}

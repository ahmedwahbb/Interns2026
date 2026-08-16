using System;
using System.IO;
using NorthWaveConsole.Models;
using NorthWaveConsole.Services.FileLogger;
using NorthWaveConsole.Services.FileOrderRepository;
using NorthWaveConsole.Services.Notifier;

namespace NorthWaveConsole.Services
{
   
    public class OrderService
    {
        private static int _nextId = 1;
        private readonly IOrderRepository _orderRepository;
        private readonly IFileLoggerService _fileLoggerService;
        private readonly INotifierService _notifierService;

        public OrderService(IOrderRepository orderRepository, IFileLoggerService fileLoggerService, INotifierService notifierService)
        {
            _orderRepository = orderRepository;
            _fileLoggerService = fileLoggerService;
            _notifierService = notifierService;
        }

        public decimal CalculateTotal(Order order)
        {
            decimal total = 0;
            for (int i = 0; i < order.Items.Count; i++)
            {
                total = total + (order.Items[i].Price * order.Items[i].Qty);
            }
            if (order.CustomerType == CustomerType.VIP)
                total = total * 0.8m;
            else if (order.CustomerType == CustomerType.Wholesale)
                total = total * 0.85m;
            else if (order.CustomerType == CustomerType.Employee)
                total = total * 0.5m;

            order.SetTotal(total);
            return total;
        }

        public bool ProcessOrder(Order o)
        {
            if (o.Items.Count <= 0)
                throw new ArgumentException("Order must contain at least one item.");
            if (string.IsNullOrWhiteSpace(o.CustomerName))
                throw new ArgumentException("Customer name is required.");
            o.AssignId(_nextId);
            _nextId++;
            CalculateTotal(o);
            try
            {
                _orderRepository.Save(o);
                _notifierService.SendConfirmationEmail(o);
                _fileLoggerService.Log("Order processed: " + o.Id);
            }
            catch (Exception ex)
            {
                _fileLoggerService.Log($"Error occurred while processing order: {o.Id} {Environment.NewLine}{ex.Message}");
                return false;
            }
            return true;
        }
    }
}

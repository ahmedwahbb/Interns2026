using NorthWaveConsole.Enum;
using NorthWaveConsole.Models;
using NorthWaveConsole.Repositories;

namespace NorthWaveConsole.Services
{
    public class PricingOrder:IOrderPricingService
    {
        public decimal CalculateTotal(Order order)
        {
            decimal subtotal = order.Subtotal;

            decimal discount = order.Customer.Type switch
            {
                Layer.Employee => 0.15m,
                Layer.VIP => 0.10m,
                Layer.Wholesale => 0.20m,
                _ => 0m
            };

            return subtotal - (subtotal * discount);
        }
    }
}

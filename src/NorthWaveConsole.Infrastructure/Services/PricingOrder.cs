using NorthWaveConsole.Application.Interfaces;
using NorthWaveConsole.Domain.Entities;
using NorthWaveConsole.Infrastructure.Services.Discounts;

namespace NorthWaveConsole.Infrastructure.Services
{
    public class PricingOrder : IPricingService
    {
        public decimal CalculateTotal(Order order)
        {
            decimal subtotal = order.Subtotal;

            IDiscountStrategy strategy = DiscountStrategyFactory.GetStrategy(order.CustomerType);
            decimal discountRate = strategy.GetDiscountRate();

            return subtotal - (subtotal * discountRate);
        }
    }
}

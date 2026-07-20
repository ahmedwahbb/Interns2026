using NorthWaveConsole.Interfaces;
using NorthWaveConsole.Models;
using NorthWaveConsole.Services.Discounts;

namespace NorthWaveConsole.Services
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

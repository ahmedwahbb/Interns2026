using NorthWaveConsole.Application.Interfaces;

namespace NorthWaveConsole.Infrastructure.Services.Discounts
{
    public class WholesaleDiscountStrategy : IDiscountStrategy
    {
        public decimal GetDiscountRate() => 0.20m;
    }
}

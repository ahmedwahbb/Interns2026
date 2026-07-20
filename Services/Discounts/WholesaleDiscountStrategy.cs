using NorthWaveConsole.Interfaces;

namespace NorthWaveConsole.Services.Discounts
{
    public class WholesaleDiscountStrategy : IDiscountStrategy
    {
        public decimal GetDiscountRate() => 0.20m;
    }
}

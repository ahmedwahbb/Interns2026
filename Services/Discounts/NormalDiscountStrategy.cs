using NorthWaveConsole.Interfaces;

namespace NorthWaveConsole.Services.Discounts
{
    public class NormalDiscountStrategy : IDiscountStrategy
    {
        public decimal GetDiscountRate() => 0m;
    }
}

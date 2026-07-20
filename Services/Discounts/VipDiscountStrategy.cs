using NorthWaveConsole.Interfaces;

namespace NorthWaveConsole.Services.Discounts
{
    public class VipDiscountStrategy : IDiscountStrategy
    {
        public decimal GetDiscountRate() => 0.10m;
    }
}

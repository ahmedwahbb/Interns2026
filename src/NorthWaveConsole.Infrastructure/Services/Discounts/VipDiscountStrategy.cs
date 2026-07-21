using NorthWaveConsole.Application.Interfaces;

namespace NorthWaveConsole.Infrastructure.Services.Discounts
{
    public class VipDiscountStrategy : IDiscountStrategy
    {
        public decimal GetDiscountRate() => 0.10m;
    }
}

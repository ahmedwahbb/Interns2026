using NorthWaveConsole.Application.Interfaces;

namespace NorthWaveConsole.Infrastructure.Services.Discounts
{
    public class NormalDiscountStrategy : IDiscountStrategy
    {
        public decimal GetDiscountRate() => 0m;
    }
}

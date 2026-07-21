using NorthWaveConsole.Application.Interfaces;

namespace NorthWaveConsole.Infrastructure.Services.Discounts
{
    public class EmployeeDiscountStrategy : IDiscountStrategy
    {
        public decimal GetDiscountRate() => 0.15m;
    }
}

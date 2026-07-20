using NorthWaveConsole.Interfaces;

namespace NorthWaveConsole.Services.Discounts
{
    public class EmployeeDiscountStrategy : IDiscountStrategy
    {
        public decimal GetDiscountRate() => 0.15m;
    }
}

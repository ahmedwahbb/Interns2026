using NorthWaveConsole.Models;

namespace NorthWaveConsole.Services.Discounts;

public class DiscountStrategyFactory : IDiscountStrategyFactory
{
    public IDiscountStrategy GetStrategy(CustomerType customerType)
    {
        return customerType switch
        {
            CustomerType.VIP => new VipDiscountStrategy(),
            CustomerType.Employee => new EmployeeDiscountStrategy(),
            CustomerType.Wholesale => new WholesaleDiscountStrategy(),
            _ => new NoDiscountStrategy(),
        };
    }
}
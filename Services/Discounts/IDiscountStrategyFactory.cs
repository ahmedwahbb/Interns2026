using NorthWaveConsole.Models;

namespace NorthWaveConsole.Services.Discounts;

public interface IDiscountStrategyFactory
{
    IDiscountStrategy GetStrategy(CustomerType customerType);
}
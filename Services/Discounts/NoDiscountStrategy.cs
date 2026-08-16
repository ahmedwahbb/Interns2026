namespace NorthWaveConsole.Services.Discounts;

public class NoDiscountStrategy : IDiscountStrategy
{
    public decimal Apply(decimal total)
    {
        return total;
    }
}
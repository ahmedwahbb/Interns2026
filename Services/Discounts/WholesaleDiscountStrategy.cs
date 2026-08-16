namespace NorthWaveConsole.Services.Discounts;

public class WholesaleDiscountStrategy : IDiscountStrategy
{
    public decimal Apply(decimal total)
    {
        return total * 0.85m;
    }
}
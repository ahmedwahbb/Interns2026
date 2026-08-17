namespace NorthWaveConsole.Services.Discounts;

public class VipDiscountStrategy : IDiscountStrategy
{
    public decimal Apply(decimal total)
    {
        return total * 0.8m;
    }
}
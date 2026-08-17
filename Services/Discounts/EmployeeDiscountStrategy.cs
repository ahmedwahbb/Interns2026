namespace NorthWaveConsole.Services.Discounts;

public class EmployeeDiscountStrategy : IDiscountStrategy
{
    public decimal Apply(decimal total)
    {
       return total * 0.5m;
    }
}
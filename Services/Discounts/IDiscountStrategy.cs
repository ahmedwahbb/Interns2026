namespace NorthWaveConsole.Services.Discounts;

public interface IDiscountStrategy
{
    decimal Apply(decimal total);
}
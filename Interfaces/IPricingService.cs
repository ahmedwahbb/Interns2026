using NorthWaveConsole.Models;

namespace NorthWaveConsole.Interfaces
{
    public interface IPricingService
    {
        decimal CalculateTotal(Order order);
    }
}

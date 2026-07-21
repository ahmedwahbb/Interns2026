using NorthWaveConsole.Domain.Entities;

namespace NorthWaveConsole.Application.Interfaces
{
    public interface IPricingService
    {
        decimal CalculateTotal(Order order);
    }
}

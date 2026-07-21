using NorthWaveConsole.Domain.Entities;

namespace NorthWaveConsole.Application.Interfaces
{
    public interface IOrderLogger
    {
        void Log(Order order, string message);
        void LogError(Order order, string errorMessage);
    }
}

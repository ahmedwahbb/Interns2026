using NorthWaveConsole.Models;

namespace NorthWaveConsole.Interfaces
{
    public interface IOrderLogger
    {
        void Log(Order order, string message);
        void LogError(Order order, string errorMessage);
    }
}

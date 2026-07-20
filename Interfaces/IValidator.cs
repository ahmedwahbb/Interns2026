using NorthWaveConsole.Models;

namespace NorthWaveConsole.Interfaces
{
    public interface IValidator
    {
        bool IsValid(Order order, out string reason);
    }
}

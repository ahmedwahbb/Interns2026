using NorthWaveConsole.Models;

namespace NorthWaveConsole.Interfaces
{
    public interface INotificationService
    {
        void Notify(Order order);
    }
}

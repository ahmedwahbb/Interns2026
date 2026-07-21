using NorthWaveConsole.Domain.Entities;

namespace NorthWaveConsole.Application.Interfaces
{
    public interface INotificationService
    {
        void Notify(Order order);
    }
}

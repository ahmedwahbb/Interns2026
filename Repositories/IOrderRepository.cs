using NorthWaveConsole.Models;

namespace NorthWaveConsole.Repositories
{
    public interface IOrderRepository
    {
        void Save(Order order);
    }
}

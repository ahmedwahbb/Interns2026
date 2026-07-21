using NorthWaveConsole.Domain.Entities;

namespace NorthWaveConsole.Application.Interfaces
{
    public interface IOrderRepository
    {
        void Add(Order order);
        Order GetById(int id);
    }
}

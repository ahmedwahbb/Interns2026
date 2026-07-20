using System.Collections.Generic;
using NorthWaveConsole.Models;

namespace NorthWaveConsole.Interfaces
{
    public interface IOrderRepository
    {
        void Add(Order order);
        IReadOnlyList<Order> GetPending();
        void ClearPending();
    }
}

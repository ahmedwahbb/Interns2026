using System.Collections.Generic;
using NorthWaveConsole.Interfaces;
using NorthWaveConsole.Models;

namespace NorthWaveConsole.Services
{
    // Repository pattern: مسؤول بس عن تجميع الـ orders، مش عن الـ persistence نفسها.
    // الـ persistence الفعلية بتحصل في الـ UnitOfWork.Complete()
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> _pendingOrders = new();

        public void Add(Order order)
        {
            _pendingOrders.Add(order);
        }

        public IReadOnlyList<Order> GetPending() => _pendingOrders;

        public void ClearPending() => _pendingOrders.Clear();
    }
}

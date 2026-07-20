using System;
using System.IO;
using NorthWaveConsole.Interfaces;

namespace NorthWaveConsole.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private const string FileName = "orders.txt";
        private readonly OrderRepository _orderRepository;
        private bool _disposed;

        public IOrderRepository Orders => _orderRepository;

        public UnitOfWork()
        {
            _orderRepository = new OrderRepository();
        }

        // بيكتب كل الـ orders المعلّقة (pending) لملف orders.txt دفعة واحدة
        // ده الفرق عن SaveOrder القديمة اللي كانت بتكتب order بـ order مباشرة
        public int Complete()
        {
            var pending = _orderRepository.GetPending();
            int savedCount = 0;

            foreach (var order in pending)
            {
                string line = $"[Order #{order.Id}] {order.CustomerName} ({order.CustomerType}) - " +
                              $"Items: {order.ItemsCount}, Total: {order.Total:C}, Status: {order.Status}";

                File.AppendAllText(FileName, line + Environment.NewLine);
                savedCount++;
            }

            _orderRepository.ClearPending();
            return savedCount;
        }

        public void Dispose()
        {
            if (_disposed) return;
            _orderRepository.ClearPending();
            _disposed = true;
        }
    }
}

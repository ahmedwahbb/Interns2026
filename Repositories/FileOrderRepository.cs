using System;
using System.IO;
using NorthWaveConsole.Models;

namespace NorthWaveConsole.Repositories
{
    public class FileOrderRepository : IOrderRepository
    {
        private const string FileName = "orders.txt";

        public void Save(Order order)
        {
            string line = $"[Order #{order.Id}] {order.CustomerName} ({order.CustomerType}) - " +
                          $"Items: {order.ItemsCount}, Total: {order.Total:C}, Status: {order.Status}";

            File.AppendAllText(FileName, line + Environment.NewLine);
        }
    }
}

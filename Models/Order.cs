using System.Collections.Generic;

namespace NorthWaveConsole.Models
{
    public enum CustomerType
    {
        Regular,
        VIP,
        Wholesale,
        Employee
    }
    public enum OrderStatus
    {
        New,
        Processed,
        Failed
    }
    public class Order
    {
        public int Id { get; private set; }

        public string CustomerName { get; private set; }

        public CustomerType CustomerType { get; private set; }

        public IReadOnlyList<OrderItem> Items => _items;

        public OrderStatus Status { get; private set; }

        public decimal Total { get; private set; }

        private List<OrderItem> _items = new();
    }
}
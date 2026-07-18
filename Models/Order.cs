using NorthWaveConsole.Enum;
using System.Collections.Generic;
using System.Linq;

namespace NorthWaveConsole.Models
{
    public class Order
    {
        public int Id { get; private set; }
        public Customer Customer { get; private set; }

        private readonly List<OrderItem> _items = new();
        public IReadOnlyList<OrderItem> Items => _items;
        public int ItemsCount => _items.Count;

        public Status Status { get; private set; } = Status.Pending;
        public decimal Total { get; private set; }
        public decimal Subtotal => _items.Sum(item => item.Price * item.Qty);
        public string FailureReason { get; private set; }

        public Order(int id, Customer customer)
        {
            Id = id;
            Customer = customer;
        }

        public void AddItem(OrderItem item)
        {
            _items.Add(item);
        }

        public void MarkValidated() => Status = Status.Validated;

        public void SetTotal(decimal total)
        {
            Total = total;
            Status = Status.Priced;
        }

        public void MarkSaved() => Status = Status.Saved;
        public void MarkNotified() => Status = Status.Notified;
        public void MarkCompleted() => Status = Status.Completed;

        public void MarkFailed(string reason)
        {
            Status = Status.Failed;
            FailureReason = reason;
        }
    }
}

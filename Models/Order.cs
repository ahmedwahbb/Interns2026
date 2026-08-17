using System.Collections.Generic;

namespace NorthWaveConsole.Models
{
    public class Order
    {
        public int Id { get; private set; }

        public Customer Customer { get; private set; }

        private readonly List<OrderItem> _items = new List<OrderItem>();
        public IReadOnlyList<OrderItem> Items => _items;
        public string Status { get; private set; }

        public decimal Total { get; private set; }

        public string FailureReason { get; private set; }


        public Order(Customer customer)
        {
            Customer = customer;
            
            _items = new List<OrderItem>();

            Status = "Pending";
            Total = 0;
            FailureReason = "";
        }


        public void AddItem(OrderItem item)
        {
            if (item == null)
        return;
            _items.Add(item);
        }


        private decimal GetSubtotal()
        {
            decimal total = 0;

            foreach (OrderItem item in _items)
            {
                total += item.GetSubtotal();
            }

            return total;
        }


        internal decimal GetTotal(decimal discountMultiplier)
        {
            return GetSubtotal() * discountMultiplier;
        }


        internal void SetId(int id)
        {
            Id = id;
        }


        internal void SetStatus(string status)
        {
            Status = status;
        }


        internal void SetTotal(decimal total)
        {
            Total = total;
        }


        public void SetFailureReason(string reason)
        {
            FailureReason = reason;
        }
    }
}
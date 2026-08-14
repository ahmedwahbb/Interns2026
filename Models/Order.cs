using System.Collections.Generic;

namespace NorthWaveConsole.Models
{
    public class Order
    {
        public int Id { get; private set; }

        public string CustomerName { get; private set; }

        public string CustomerType { get; private set; }

        public List<OrderItem> Items { get; private set; }

        public string Status { get; private set; }

        public decimal Total { get; private set; }

        public string FailureReason { get; private set; }


        public Order(string customerName, string customerType)
        {
            CustomerName = customerName;
            CustomerType = customerType;

            Items = new List<OrderItem>();

            Status = "Pending";
            Total = 0;
            FailureReason = "";
        }


        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }


        public decimal GetSubtotal()
        {
            decimal total = 0;

            foreach (OrderItem item in Items)
            {
                total += item.GetSubtotal();
            }

            return total;
        }


        public decimal GetTotal(decimal discountMultiplier)
        {
            return GetSubtotal() * discountMultiplier;
        }


        public void SetId(int id)
        {
            Id = id;
        }


        public void SetStatus(string status)
        {
            Status = status;
        }


        public void SetTotal(decimal total)
        {
            Total = total;
        }


        public void SetFailureReason(string reason)
        {
            FailureReason = reason;
        }
    }
}
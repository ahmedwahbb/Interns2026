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

        public OrderStatus Status { get; private set; } =  OrderStatus.New;

        public decimal Total { get; private set; }

        private List<OrderItem> _items = new();
        
        public Order(string customerName, CustomerType customerType)
        {
            if (string.IsNullOrWhiteSpace(customerName))
                throw new ArgumentException("Customer name is required.", nameof(customerName));
            CustomerName = customerName;
            CustomerType = customerType;
        }

        public void AssignId(int id)
        {
            Id = id;
        }
        public void MaskedFail()
        {
            Status = OrderStatus.Failed;
        }
        public void MaskedSuccess()
        {
            Status = OrderStatus.Processed;
        }
        public void AddItem(OrderItem item)
        {
            ArgumentNullException.ThrowIfNull(item);
            _items.Add(item);
        }
        public void SetTotal(decimal total)
        {
            if (total < 0)
                throw new ArgumentException("Total cannot be negative.", nameof(total));
            Total = total;
        }
    }
}
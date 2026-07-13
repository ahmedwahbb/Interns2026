using NorthWaveConsole.Enum;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NorthWaveConsole.Models
{
    public class Order
    {
        public int Id { get; private set; }
        public string CustomerName { get; private set; }
        public Layer CustomerType { get; private set; }
        private readonly List<OrderItem> _items = new();
        public int ItemsCount => _items.Count;

        public Status Status { get; private set; }
        public decimal Total { get; private set; }
        public decimal Subtotal => _items.Sum(item => item.Price * item.Qty);


        public Order(string CName , Layer layer)
        {
            CustomerName = CName;
            CustomerType = layer;
            Status = Status.New;


        }
        // private set 
        public void SetStatus(Status status) => Status = status;    
        public void SetTotal(decimal total) => Total = total;
        public void AddItem(OrderItem item) => _items.Add(item);
        public void SetId(int id) =>  Id = id;
        public void 
        



    }
}

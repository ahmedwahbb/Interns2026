using System.Collections.Generic;

namespace NorthWaveConsole.Models
{
    public class Order
    {
        public int Id;
        public string CustomerName;
        public string CustomerType;
        public List<OrderItem> Items = new List<OrderItem>();
        public string Status; 
        public decimal Total;
    }
}

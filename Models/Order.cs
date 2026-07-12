using System.Collections.Generic;

namespace NorthWaveConsole.Models
{
    // NOTE FOR INTERNS: this class is a grab-bag of public mutable fields
    // and no invariants. Nothing stops you from creating an Order with
    // negative quantities, no items, or a status that doesn't make sense.
    // That's on purpose - it's your Week 3 job to give this a real Domain model.
    public class Order
    {
        public int Id;
        public string CustomerName;
        public string CustomerType; // "VIP", "Wholesale", "Employee", or anything else typed in
        public List<OrderItem> Items = new List<OrderItem>();
        public string Status; // free-text: "New", "Paid", "Shipped"... no enum, no validation
        public decimal Total;
    }
}

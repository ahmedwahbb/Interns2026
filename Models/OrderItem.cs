namespace NorthWaveConsole.Models
{
    public class OrderItem
    {
        public string ProductName { get; private set; }
        public decimal Price { get; private set; }
        public int Qty { get; private set; }

        public OrderItem(string productName, decimal price, int qty)
        {
            ProductName = productName;
            Price = price;
            Qty = qty;
        }
    }
}

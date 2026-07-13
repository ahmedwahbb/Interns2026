namespace NorthWaveConsole.Models
{
    public class OrderItem
    {
        public string ProductName;
        public decimal Price;
        public int Qty;
        public OrderItem(string productName, decimal price, int qty)
        {
            ProductName = productName;
            Price = price;
            Qty = qty;
        }
    }
}

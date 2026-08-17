namespace NorthWaveConsole.Models
{
    public class OrderItem
    {
        public string ProductName  { get; private set; }
        public decimal Price  { get; private set; }
        public int Qty   { get; private set; }

        public OrderItem(string productName, decimal price, int quantity)
        {
            if (string.IsNullOrEmpty(productName))
                throw new ArgumentException("Product name cannot be null or empty");
            if (price < 0)
                throw new ArgumentException("Price cannot be negative");
            if (quantity <= 0)
                throw new ArgumentException("Quantity cannot be at least 1");
            ProductName = productName;
            Price = price;
            Qty = quantity;
        }
    }
}

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
        if (qty<0 || price < 0)
        {
            throw new ArgumentException("Quantity and price must be positive numbers.", nameof(qty));
        }
    }

    public decimal GetSubtotal()
    {
        return Price * Qty;
    }
}
}

namespace NorthWaveConsole.Models
{
  public class OrderItem
  {
    public string ProductName {get; }
    public decimal Price {get; }
    public int Qty {get; }

    public OrderItem(string productName, decimal price, int qty)
    {
      ProductName = productName;
      Price = price;
      Qty = qty;
    }
  }
}

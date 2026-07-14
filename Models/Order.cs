using System.Collections.Generic;
using NorthWaveConsole.Enums;

namespace NorthWaveConsole.Models
{
  public class Order
  {
    public int Id { get; private set; }
    public string CustomerName { get; private set; }
    public CustomerType CustomerType { get; private set; }
    private readonly List<OrderItem> _items = new();
    public IReadOnlyCollection<OrderItem> Items => _items;
    public OrderStatus Status { get; private set; }
    public decimal Total { get; private set; }
    public decimal Subtotal => _items.Sum(item => item.Price * item.Qty);

    public Order(string customerName, CustomerType customerType)
    {
      CustomerName = customerName;
      CustomerType = customerType;
      Status = OrderStatus.New;
    }

    public void AddItem(OrderItem item)
    {
      _items.Add(item);
    }

    public void SetId(int id)
    {
      Id = id;
    }

    public void SetStatus(OrderStatus status)
    {
      Status = status;
    }

    public void SetTotal(decimal total)
    {
      Total = total;
    }
  }
}

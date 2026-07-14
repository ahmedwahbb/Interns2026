using System.Collections.Generic;
using NorthWaveConsole.Enums;

namespace NorthWaveConsole.Models
{
  public class Order : BaseEntity
  {
    public Customer Customer { get; }
    private readonly List<OrderItem> _items = new();
    public IReadOnlyCollection<OrderItem> Items => _items;
    public OrderStatus Status { get; private set; }
    public decimal Total { get; private set; }
    public decimal Subtotal => _items.Sum(item => item.Price * item.Qty);

    public Order(Customer customer)
    {
      Customer = customer;
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

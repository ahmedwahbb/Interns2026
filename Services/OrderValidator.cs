
using NorthWaveConsole.Models;

namespace NorthWaveConsole.Services
{
  public class OrderValidator
  {
    public ValidationResult Validate(Order order)
    {
    if (order.Customer == null)
      return new ValidationResult(false, "Customer is required.");

    if (string.IsNullOrWhiteSpace(order.Customer.Name))
      return new ValidationResult(false, "Customer name is required.");

    if (!order.Items.Any())
      return new ValidationResult(false, "Order must contain at least one item.");

    return new ValidationResult(true);
    }
  }
}
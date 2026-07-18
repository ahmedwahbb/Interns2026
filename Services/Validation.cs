using NorthWaveConsole.Models;
using NorthWaveConsole.Repositories;

namespace NorthWaveConsole.Services
{
    public class Validation : IOrderValidator
    {
        public bool IsValid(Order order, out string reason)
        {
            if (string.IsNullOrWhiteSpace(order.Customer.Name))
            {
                reason = "Customer name is missing.";
                return false;
            }
            if (order.ItemsCount == 0)
            {
                reason = "Order has no items.";
                return false;
            }
            reason = null;
            return true;
        }
    }
}

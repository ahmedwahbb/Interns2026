using NorthWaveConsole.Interfaces;
using NorthWaveConsole.Models;

namespace NorthWaveConsole.Services
{
    public class Validation : IValidator
    {
        public bool IsValid(Order order, out string reason)
        {
            if (string.IsNullOrWhiteSpace(order.CustomerName))
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

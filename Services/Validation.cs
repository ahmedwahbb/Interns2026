using NorthWaveConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWaveConsole.Services
{
    public class Validation
    {
        ///
        public bool IsValid(Order order)
        {
            if (order == null)
                return false;

            if (string.IsNullOrWhiteSpace(order.CustomerName))
                return false;

            if (order.ItemsCount == 0)
                return false;

            return true;
        }
    }
}

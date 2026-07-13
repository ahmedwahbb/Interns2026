using NorthWaveConsole.Enum;
using NorthWaveConsole.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWaveConsole.Services
{
    public class PricingOrder
    {
        public decimal CalculateTotal(Order order)
        {
            decimal total = order.Subtotal;

            switch (order.CustomerType)
            {
                case Layer.VIP:
                    total *= 0.8m;
                    break;

                case Layer.Wholesale:
                    total *= 0.85m;
                    break;

                case Layer.Employee:
                    total *= 0.5m;
                    break;
            }

            return total;
        }
    }
}

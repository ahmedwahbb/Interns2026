using NorthWaveConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWaveConsole.Repositories
{
    public interface IOrderPricingService
    {
        decimal CalculateTotal(Order order);
    }
}

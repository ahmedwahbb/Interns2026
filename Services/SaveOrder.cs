using NorthWaveConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWaveConsole.Services
{
    public class SaveOrder
    {
        public void Save(Order order)
        {
            File.AppendAllText("orders.txt",
              $"{order.Id}," + $"{order.CustomerName}," + $"{order.CustomerType}," + $"{order.Total}," + $"{order.Status}" + $"{Environment.NewLine}");
        }
    }
}

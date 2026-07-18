using NorthWaveConsole.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWaveConsole.Models
{
    public class Customer
    {
        public string Name { get; private set; }
        public Layer Type { get; private set; }

        public Customer(string name, Layer type)
        {
            Name = name;
            Type = type;
        }
    }
}

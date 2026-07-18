using NorthWaveConsole.Repositories.NorthWaveConsole.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWaveConsole.Services
{
    public class OrderIdGenerator : IOrderIdGenerator
    {
        private int _nextId = 1;

        public int Next()
        {
            return _nextId++;
        }
    }
}

using NorthWaveConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWaveConsole.Repositories
{
    public interface IOrderLogger
    {
        void Log(Order order, string message);
        void LogError(Order order, string reason);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWaveConsole.Services
{
    public  class LoggerOrder
    {
        public void Log(string message)
        {
            File.AppendAllText("app.log", $"{DateTime.Now}: {message}{Environment.NewLine}");
        }
    }
}

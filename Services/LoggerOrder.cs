using NorthWaveConsole.Models;
using NorthWaveConsole.Repositories;
using System;
using System.IO;

namespace NorthWaveConsole.Services
{
    public class LoggerOrder : IOrderLogger
    {
        private const string FileName = "app.log";

        public void Log(Order order, string message)
        {
            File.AppendAllText(FileName, $"{DateTime.Now}: [Order #{order.Id}] {message}{Environment.NewLine}");
        }

        public void LogError(Order order, string reason)
        {
            File.AppendAllText(FileName, $"{DateTime.Now}: [Order #{order.Id}] FAILED - {reason}{Environment.NewLine}");
        }
    }
}

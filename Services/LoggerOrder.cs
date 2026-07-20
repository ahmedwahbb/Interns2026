using System;
using System.IO;
using NorthWaveConsole.Interfaces;
using NorthWaveConsole.Models;

namespace NorthWaveConsole.Services
{
    public class LoggerOrder : IOrderLogger
    {
        private const string FileName = "app.log";

        public void Log(Order order, string message)
        {
            string line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | Order #{order.Id} | {order.Status} | {message}";
            File.AppendAllText(FileName, line + Environment.NewLine);
        }

        public void LogError(Order order, string errorMessage)
        {
            Log(order, $"ERROR - {errorMessage}");
        }
    }
}

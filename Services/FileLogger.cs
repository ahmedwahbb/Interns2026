using NorthWaveConsole.Repository;

namespace NorthWaveConsole.Services
{
  public class FileLogger : ILogger
  {
    public void Log(string message)
    {
      File.AppendAllText("app.log", $"{DateTime.Now}: {message}{Environment.NewLine}");
    }
  }
}
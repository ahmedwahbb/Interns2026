using NorthWaveConsole.Repository;

namespace NorthWaveConsole.Logging
{
  public class FileLogger : IAppLogger
  {
    public void Log(string message)
    {
      File.AppendAllText("app.log", $"{DateTime.Now}: {message}{Environment.NewLine}");
    }
  }
}
namespace NorthWaveConsole.Services.FileLogger;

public class FileLoggerService : IFileLoggerService
{
    public void Log(string message)
    {
        File.AppendAllText("app.log", $"{DateTime.Now}: {message}{Environment.NewLine}");
    }
}
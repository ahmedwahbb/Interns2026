namespace NorthWaveConsole.Services.FileLogger;

public interface IFileLoggerService
{
    void LogToFile(string message);
}
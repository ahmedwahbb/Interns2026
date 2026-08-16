using NorthWaveConsole.Models;
namespace NorthWaveConsole.Services.Notifier;

public interface INotifierService
{
    void SendConfirmationEmail(Order order);
}
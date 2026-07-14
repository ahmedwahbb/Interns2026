using NorthWaveConsole.Models;

namespace NorthWaveConsole.Notifications
{
  public interface INotificationService
  {
    void SendOrderConfirmation(Order order);
  }
}
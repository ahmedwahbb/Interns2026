using NorthWaveConsole.Models;

namespace NorthWaveConsole.Repository
{
  public interface INotificationService
  {
    void SendOrderConfirmation(Order order);
  }
}
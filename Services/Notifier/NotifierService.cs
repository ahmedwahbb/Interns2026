using NorthWaveConsole.Models;
namespace NorthWaveConsole.Services.Notifier;

public class NotifierService : INotifierService
{
    public void SendConfirmationEmail(Order order)
    {
        Console.WriteLine($"[EMAIL] To: {order.CustomerName} - Your order #{order.Id} totalling {order.Total:C} was received.");
    }
}
using NorthWaveConsole.Models;

namespace NorthWaveConsole.Services.FileOrderRepository;

public class FileRepository : IOrderRepository
{
    public void Save(Order order)
    {
        File.AppendAllText("orders.txt",
            $"{order.Id},{order.CustomerName},{order.CustomerType},{order.Total},{order.Status}{Environment.NewLine}");
    }
}
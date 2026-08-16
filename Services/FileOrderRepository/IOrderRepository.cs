using NorthWaveConsole.Models;

namespace NorthWaveConsole.Services.FileOrderRepository;

public interface IOrderRepository
{
    void Save(Order order);
}
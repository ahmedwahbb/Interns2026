using NorthWaveConsole.Application.DTOs;

namespace NorthWaveConsole.Application.Interfaces
{
    public interface IOrderService
    {
        OrderResult ProcessOrder(CreateOrderRequest request);
        OrderResult GetById(int id);
        int CommitOrders();
    }
}

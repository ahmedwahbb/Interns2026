using System.Collections.Generic;
using NorthWaveConsole.Domain.Enums;

namespace NorthWaveConsole.Application.DTOs
{
    public class CreateOrderRequest
    {
        public string CustomerName { get; set; }
        public Layer CustomerType { get; set; }
        public List<CreateOrderItemRequest> Items { get; set; } = new();
    }
}

using System.Collections.Generic;

namespace NorthWaveConsole.Application.DTOs
{
    public class BatchOrdersRequest
    {
        public List<CreateOrderRequest> Orders { get; set; } = new();
    }
}

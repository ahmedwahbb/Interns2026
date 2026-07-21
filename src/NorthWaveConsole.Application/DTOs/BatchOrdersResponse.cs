using System.Collections.Generic;

namespace NorthWaveConsole.Application.DTOs
{
    public class BatchOrdersResponse
    {
        public List<OrderResult> Results { get; set; } = new();

        
        public int CommittedCount { get; set; }
    }
}

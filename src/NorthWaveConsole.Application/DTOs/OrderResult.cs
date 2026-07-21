using NorthWaveConsole.Domain.Enums;

namespace NorthWaveConsole.Application.DTOs
{
    public class OrderResult
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public Layer CustomerType { get; set; }
        public Status Status { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public string FailureReason { get; set; }
    }
}

namespace NorthWaveConsole.Application.DTOs
{
    public class CreateOrderItemRequest
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
    }
}

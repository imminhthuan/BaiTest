namespace BaiTest.DTOs
{
    public class OrderItemResponseDTO
    {
        public int OrderDetailId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public string ProductName { get; set; }
    }
}

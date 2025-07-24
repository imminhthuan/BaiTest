namespace BaiTest.DTOs
{
    public class ResponseOrderDTO
    {
        public class OrderDetailDto
        {
            public int OrderId { get; set; }
            public string CustomerName { get; set; }
            public DateTime OrderDate { get; set; }
            public decimal TotalAmount { get; set; }
            public List<OrderItemDto> Items { get; set; }
        }

        public class OrderItemDto
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
        }
    }
}

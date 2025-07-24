namespace BaiTest.DTOs
{
    public class UpdateOrderDTO
    {
        public int OrderId { get; set; } // bắt buộc để biết order nào đang cập nhật
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int CustomerId { get; set; }
    }
}

using static BaiTest.DTOs.CreateOrderDTO;
using static BaiTest.DTOs.ResponseOrderDTO;

namespace BaiTest.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDetailDto> CreateOrderAsync(OrderCreateDto dto);
        Task<List<OrderDetailDto>> GetAllOrdersAsync(DateTime? fromDate, DateTime? toDate, int? customerId);
        Task<OrderDetailDto?> GetOrderByIdAsync(int id);
    }
}

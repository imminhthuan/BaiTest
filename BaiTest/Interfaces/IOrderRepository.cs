using BaiTest.Models;

namespace BaiTest.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(Order order);
        Task<List<Order>> GetOrdersAsync(DateTime? fromDate, DateTime? toDate, int? customerId);
        Task<Order?> GetOrderByIdAsync(int id);
    }
}

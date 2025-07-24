using BaiTest.Interfaces;
using BaiTest.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BaiTest.Ripositorys
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Order> CreateOrderAsync(Order order)
        {
            var customer = await _context.Customers.FindAsync(order.CustomerId);
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<List<Order>> GetOrdersAsync(DateTime? fromDate, DateTime? toDate, int? customerId)
        {
            var query = _context.Orders.Include(o => o.Customer).Include(o => o.OrderItem).ThenInclude(oi => oi.Product).AsQueryable();

            if (fromDate.HasValue)
                query = query.Where(o => o.OrderDate >= fromDate.Value);

            if (toDate.HasValue)
                query = query.Where(o => o.OrderDate <= toDate.Value);

            if (customerId.HasValue)
                query = query.Where(o => o.CustomerId == customerId);

            return await query.ToListAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _context.Orders.Include(o => o.Customer).Include(o => o.OrderItem).ThenInclude(oi => oi.Product).FirstOrDefaultAsync(o => o.OrderId == id);
        }
    }
}

using AutoMapper;
using BaiTest.DTOs;
using BaiTest.Interfaces;
using BaiTest.Models;
using static BaiTest.DTOs.ResponseOrderDTO;

namespace BaiTest.Services
{
    public class OrderService : IOrderService 
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IProductRepository _productrepository;
        private readonly ICustomerRepository _customerRepo;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, ICustomerRepository customerRepository, IMapper mapper)
        {
            _orderRepo = orderRepository;
            _customerRepo = customerRepository;
            _productrepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ResponseOrderDTO.OrderDetailDto> CreateOrderAsync(CreateOrderDTO.OrderCreateDto createOrderDTO)
        {
            var customer = await _customerRepo.GetByIdAsync(createOrderDTO.CustomerId);
            if (customer == null) throw new Exception("Customer not found");

            var order = new Order
            {
                CustomerId = createOrderDTO.CustomerId,
                OrderDate = DateTime.Now,
                OrderItem = new List<OrderItem>()
            };


            decimal totalAmount = 0;
            foreach (var item in createOrderDTO.Items)
            {
                var product = await _productrepository.GetByIdAsync(item.ProductId);
                if (product == null) throw new Exception("Product not found");

                var orderItem = new OrderItem
                {
                    ProductId = product.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price
                };

                order.OrderItem.Add(orderItem);
                totalAmount += product.Price * item.Quantity;
            }

            order.TotalAmount = totalAmount;
            var created = await _orderRepo.CreateOrderAsync(order);
            return _mapper.Map<OrderDetailDto>(created);
        }


        public async Task<List<OrderDetailDto>> GetAllOrdersAsync(DateTime? fromDate, DateTime? toDate, int? customerId)
        {
            var orders = await _orderRepo.GetOrdersAsync(fromDate, toDate, customerId);
            return _mapper.Map<List<OrderDetailDto>>(orders);
        }

        public async Task<OrderDetailDto?> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepo.GetOrderByIdAsync(id);
            return _mapper.Map<OrderDetailDto>(order);
        }

    }
}

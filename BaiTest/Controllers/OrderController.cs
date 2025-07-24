using BaiTest.DTOs;
using BaiTest.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseOrderDTO.OrderDetailDto>> CreateOrder([FromBody] CreateOrderDTO.OrderCreateDto orderDto)
        {
            try
            {
                if (orderDto == null || orderDto.Items == null || orderDto.Items.Count == 0)
                {
                    return BadRequest("Dữ liệu đơn hàng không hợp lệ.");
                }

                var result = await _orderService.CreateOrderAsync(orderDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi server: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseOrderDTO.OrderDetailDto>> GetOrder(int id)
        {
            try
            {
                var result = await _orderService.GetOrderByIdAsync(id);
                if (result == null)
                {
                    return NotFound($"Không tìm thấy đơn hàng với ID = {id}");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi server: {ex.Message}");
            }
        }

        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseOrderDTO.OrderDetailDto>>> GetAllOrders([FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate, [FromQuery] int? customerId)
        {
            try
            {
                var result = await _orderService.GetAllOrdersAsync(fromDate, toDate, customerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi server: {ex.Message}");
            }
        }
    }
}

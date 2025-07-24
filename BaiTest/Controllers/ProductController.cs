using BaiTest.DTOs;
using BaiTest.Interfaces;
using BaiTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _productService.GetAllProductAsync();
            return Ok(customers);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var customer = await _productService.GetProductByIdAsync(id);
                if (customer == null)
                {
                    return NotFound();
                }
                return Ok(customer);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, "Internal server error.");
            }
          
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdproduct = await _productService.AddProductAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = createdproduct.ProductId }, createdproduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}

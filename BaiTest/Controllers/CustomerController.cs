using BaiTest.DTOs;
using BaiTest.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdCustomer = await _customerService.AddCustomerAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = createdCustomer.CustomerId }, createdCustomer);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, "Internal server error.");
            }
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCustomerDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var success = await _customerService.UpdateCustomerAsync(dto);
                if (!success)
                {
                    return NotFound($"Customer with Id {id} not found");
                }
                return Ok(success);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var success =  await _customerService.DeleteCustomerAsync(id);
                if (!success)
                {
                    return NotFound($"Customer with id {id} not found");
                }
                return NoContent();
            }
            catch (Exception ex)
            {         
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}

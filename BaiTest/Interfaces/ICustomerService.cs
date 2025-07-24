using BaiTest.DTOs;

namespace BaiTest.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<ResponseCustomerDTO>> GetAllCustomersAsync();
        Task<ResponseCustomerDTO> GetCustomerByIdAsync(int id);
        Task<ResponseCustomerDTO> AddCustomerAsync(CreateCustomerDTO customerDto);
        Task<bool> UpdateCustomerAsync(UpdateCustomerDTO customerDto);
        Task<bool> DeleteCustomerAsync(int id);
    }
}

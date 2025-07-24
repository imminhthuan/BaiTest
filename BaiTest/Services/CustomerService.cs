using AutoMapper;
using BaiTest.DTOs;
using BaiTest.Interfaces;
using BaiTest.Models;
using System.ComponentModel.DataAnnotations;

namespace BaiTest.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<ResponseCustomerDTO>> GetAllCustomersAsync()
        {
            var customer = await _customerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ResponseCustomerDTO>>(customer);
        }


        public async Task<ResponseCustomerDTO> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            return _mapper.Map<ResponseCustomerDTO>(customer);
        }

        public async Task<ResponseCustomerDTO> AddCustomerAsync(CreateCustomerDTO dto)
        {
            var customer = _mapper.Map<Customer>(dto);
            var created = await _customerRepository.AddAsync(customer);
            return _mapper.Map<ResponseCustomerDTO>(created);
        }

        public async Task<bool> UpdateCustomerAsync(UpdateCustomerDTO dto)
        {
            var customer = await _customerRepository.GetByIdAsync(dto.CustomerId);
            if (customer == null)
            {
                return false;
            }
            _mapper.Map(dto, customer);
            return await _customerRepository.UpdateAsync(customer);
        }


        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                return false;
            }
            return await _customerRepository.DeleteAsync(id);
        }
    }
}

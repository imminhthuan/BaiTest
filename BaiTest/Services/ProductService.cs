using AutoMapper;
using BaiTest.DTOs;
using BaiTest.Interfaces;
using BaiTest.Models;
using BaiTest.Ripositorys;

namespace BaiTest.Services
{
    public class ProductService : IProductService
    { 
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<ProductResponseDTO>> GetAllProductAsync()
        {
            var product = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductResponseDTO>>(product);
        }


        public async Task<ProductResponseDTO> GetProductByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            return _mapper.Map<ProductResponseDTO>(product);
        }

        public async Task<ProductResponseDTO> AddProductAsync(CreateProductDTO dto)
        {
            var product = _mapper.Map<Product>(dto);
            var created = await _repository.AddAsync(product);
            return _mapper.Map<ProductResponseDTO>(created);
        }

        public async Task<bool> UpdateProductAsync(UpdateProductDTO dto)
        {
            var product = await _repository.GetByIdAsync(dto.ProductId);
            if (product == null)
            {
                return false;
            }
            _mapper.Map(dto, product);
            return await _repository.UpdateAsync(product);
        }


        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null)
            {
                return false;
            }
            return await _repository.DeleteAsync(id);
        }
    }
}

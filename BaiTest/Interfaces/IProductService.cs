using BaiTest.DTOs;

namespace BaiTest.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDTO>> GetAllProductAsync();
        Task<ProductResponseDTO> GetProductByIdAsync(int id);
        Task<ProductResponseDTO> AddProductAsync(CreateProductDTO createProductDTO);
        Task<bool> UpdateProductAsync(UpdateProductDTO updateProductDTO);
        Task<bool> DeleteProductAsync(int id);
    }
}

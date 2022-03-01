using Assignment_3_Product.Models;

namespace Assignment_3_Product.Interfaces;

public interface IProductService
{
    public Task<List<ProductDTO>> ListAsync();
    public Task<ProductDTO> CreateAsync(ProductDTO productDTO);
    public Task<ProductDTO> UpdateAsync(ProductDTO productDTO);
    public Task<ProductDTO> DeleteAsync(Guid Id);
}

using Assignment_3_Product.Models;

namespace Assignment_3_Product.Interfaces;
public interface ICategoryService
{
    public Task<List<CategoryDTO>> ListAsync();
    public Task<CategoryDTO> CreateAsync(CategoryDTO categoryDTO);
    public Task<CategoryDTO> UpdateAsync(CategoryDTO categoryDTO);
    public Task<CategoryDTO> DeleteAsync(Guid Id);
}

using Assignment_3_Product.Interfaces;
using Assignment_3_Product.Models;
using Assignment_3_Product.DataContexts;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Assignment_3_Product.Services;

public class CategoryService : ICategoryService
{
    private readonly ProductContext _context;
    private readonly IMapper _mapper;
    public CategoryService(ProductContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<CategoryDTO>> ListAsync()
    {
        return (await _context.Categories.ToListAsync())
                .Select(x => _mapper.Map<CategoryDTO>(x)).ToList();
    }


    public async Task<CategoryDTO> CreateAsync(CategoryDTO category)
    {
        category.Id = Guid.NewGuid();
        var categoryDB = _mapper.Map<CategoryDBModel>(category);
      
        await _context.AddAsync<CategoryDBModel>(categoryDB);
        await _context.SaveChangesAsync();

        return _mapper.Map<CategoryDTO>(category);
    }

    public async Task<CategoryDTO> UpdateAsync(CategoryDTO category)
    {
        using(var toUpdateCategory = await _context.Categories.FindAsync(category.Id))
        {
            if (toUpdateCategory == null)
                throw new Exception("This person was deleted");
            _context.Entry(toUpdateCategory).State = EntityState.Detached;
        }
        
        _context.Entry(_mapper.Map<CategoryDBModel>(category)).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        
        return _mapper.Map<CategoryDTO>(category);
    }

    public async Task<CategoryDTO> DeleteAsync(Guid Id)
    {
        var toDeleteCategory = await _context.Categories.FindAsync(Id);
        
        if (toDeleteCategory == null)
            throw new Exception("This person was deleted");
    
        var deletedCategory = _context.Categories.Remove(toDeleteCategory);
        await _context.SaveChangesAsync();
       
        return _mapper.Map<CategoryDTO>(toDeleteCategory);
    }

}
using Assignment_3_Product.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Assignment_3_Product.Models;
using AutoMapper;

namespace Assignment_3_Product.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;
    public CategoryController(ICategoryService categoryService, IMapper mapper)
    {
        _categoryService = categoryService;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("/api/categories")]
    public async Task<ActionResult<List<CategoryPresentModel>>> GetCategories()
    {
        try
        { 
            return (await _categoryService.ListAsync())
            .Select(x => _mapper.Map<CategoryPresentModel>(x)).ToList();
        }   
        catch(Exception except)
        {
            return Problem(except.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<CategoryPresentModel>> CreateCategory(CategoryPresentModel category)
    {
        try
        {
            var createdCategory = await _categoryService.CreateAsync(_mapper.Map<CategoryDTO>(category));
            return _mapper.Map<CategoryPresentModel>(createdCategory);
        }   
        catch(Exception except)
        {
            return Problem(except.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult<CategoryPresentModel>> UpdateCategory(CategoryPresentModel category)
    {
        try
        {
            var updatedCategory = await _categoryService.UpdateAsync(_mapper.Map<CategoryDTO>(category));
            return _mapper.Map<CategoryPresentModel>(updatedCategory);
        }
        catch(Exception except)
        {
            return Problem(except.Message);
        }
    }

    [HttpDelete]
    public async Task<ActionResult<CategoryPresentModel>> DeleteCategory(Guid categoryId)
    {
        try
        {
            var deletedCategory = await _categoryService.DeleteAsync(categoryId);
            return _mapper.Map<CategoryPresentModel>(deletedCategory);
        }   
        catch(Exception except)
        {
            return Problem(except.Message);
        }
    }
}
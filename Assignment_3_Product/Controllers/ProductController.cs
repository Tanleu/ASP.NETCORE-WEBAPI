using Assignment_3_Product.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Assignment_3_Product.Models;
using AutoMapper;

namespace Assignment_3_Product.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;
    public ProductController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("/api/products")]
    public async Task<ActionResult<List<ProductPresentModel>>> GetProducts()
    {
        try
        {
            return (await _productService.ListAsync())
                .Select(x => _mapper.Map<ProductPresentModel>(x)).ToList();
        }
        catch (Exception except)
        {
            return Problem(except.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<ProductPresentModel>> CreateProduct(ProductPresentModel product)
    {
        try
        {
            var createdProduct = await _productService.CreateAsync(_mapper.Map<ProductDTO>(product));

            //sd auto mapper
            return _mapper.Map<ProductPresentModel>(createdProduct);
        }
        catch (Exception except)
        {
            return Problem(except.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult<ProductPresentModel>> UpdateProduct(ProductPresentModel productModel)
    {
        try
        {
            var updatedProduct = await _productService.UpdateAsync(_mapper.Map<ProductDTO>(productModel));
            return _mapper.Map<ProductPresentModel>(updatedProduct);
        }
        catch (Exception except)
        {
            return Problem(except.Message);
        }
    }

    [HttpDelete]
    public async Task<ActionResult<ProductPresentModel>> DeleteCategory(Guid personId)
    {
        try
        {
            return _mapper.Map<ProductPresentModel>(await _productService.DeleteAsync(personId));
        }
        catch (Exception except)
        {
            return Problem(except.Message);
        }
    }
}
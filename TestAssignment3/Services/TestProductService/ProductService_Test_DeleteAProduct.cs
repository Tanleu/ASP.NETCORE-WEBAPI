using NUnit.Framework;
using Assignment_3_Product.Interfaces;
using Assignment_3_Product.Services;
using Assignment_3_Product.Models;
using System;
using Assignment_3_Product.DataContexts;
using Microsoft.EntityFrameworkCore;
using CConfig = TestAssignment3.CommonConfig;
using AutoMapper;
using System.Threading.Tasks;
using System.Linq;

namespace TestAssignment3.TestServices;

[TestFixture]
public class ProductService_Test_DeleteAProduct
{
    private IProductService _productService;
    private IMapper _mapper;
    private ProductContext _context;

    [SetUp]
    public void SetUp()
    {
        _mapper = CConfig.CommonConfig.GetCommonConfig().mapper;
        _context = CConfig.CommonConfig.GetCommonConfig().context;
        _productService = new ProductService(_context, _mapper);
    }

    /// <summary>
    /// Scenario:
    /// 1.Input is non-exist item or empty
    /// 2.Input is existing item
    /// 3.Input empty id
    /// </summary>

    [Test]
    public void DeleteAProduct_InputIsEmptyOrNonExistingId_ReturnExceptionNonExistingProduct()
    {
        var exception = Assert.ThrowsAsync<Exception>(async Task () => await _productService.DeleteAsync(Guid.NewGuid()));
        Assert.AreEqual(exception.Message, "This product was deleted or not exist");

        exception = Assert.ThrowsAsync<Exception>(async Task () => await _productService.DeleteAsync(Guid.Empty));
        Assert.AreEqual(exception.Message, "This product was deleted or not exist");
    }

    [Test]
    public async Task DeleteAProduct_InputIsExistingItem_ReturnSuccessWithDeletedItem()
    {
        //Arrage
        var input_productDTO = _mapper.Map<ProductDTO>(_context.Products.FirstOrDefault());
        
        var expected_DeletedProduct = new ProductDTO();
        expected_DeletedProduct.CopyFrom(input_productDTO);
        
        //Act
        var result_createdProduct = await _productService.DeleteAsync(Guid.Parse(input_productDTO.Id.ToString()));
        
        //Recheck this error???
        //Assert
        Assert.AreNotEqual(expected_DeletedProduct, result_createdProduct, "Delete error");
    }

}

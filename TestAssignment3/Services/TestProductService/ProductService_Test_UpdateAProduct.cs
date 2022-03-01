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
public class ProductService_Test_UpdateAProduct
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
    /// 1.Input is non-exist item
    /// 2.Input is existing item
    /// 3.Input unsupported format of item
    /// </summary>

    [Test]
    public void UpdateAProduct_InputIsNewItem_ReturnExceptionNonExistingProduct()
    {
        //Arrage
        var input_productDTO = new ProductDTO()
        { 
            Id = Guid.NewGuid(), 
            Name = "Product 1", 
            Manufacture= "Lao Cai", 
            CategoryId = Guid.Parse("B3399EB3-ACD5-430E-B38A-D5993D01F03C")
        };

        var exception = Assert.ThrowsAsync<Exception>(async Task () => await _productService.UpdateAsync(input_productDTO));
        Assert.AreEqual(exception.Message, "This product was deleted or not exist");
    }

    [Test]
    public async Task UpdateAProduct_InputIsExistingItem_ReturnSuccessWithModifiedItem()
    {
        //Arrage
        var input_productDTO = _mapper.Map<ProductDTO>(_context.Products.FirstOrDefault());

        var expected_createdProduct = new ProductDTO();
        expected_createdProduct.CopyFrom(input_productDTO);
        input_productDTO.Name = input_productDTO.Name + DateTime.Now.ToLongDateString();

        //Act
        var result_createdProduct = await _productService.UpdateAsync(input_productDTO);
        
        //Assert
        Assert.AreNotEqual(expected_createdProduct, result_createdProduct, "Update error");
    }

    [Test]
    public async Task UpdateAProduct_InputIsLackFormatItem_ReturError()
    {
        //Arrage Lack of Name and Manufacture
        //Arrage
        var existed_productDTO = _mapper.Map<ProductDTO>(_context.Products.LastOrDefault());
        var input_productDTO = new ProductDTO()
        { 
            Id = existed_productDTO.Id,  
            CategoryId = existed_productDTO.CategoryId
        };

        //Act
         var result = await _productService.UpdateAsync(input_productDTO);
        
        //Act/Assert
        Assert.ThrowsAsync<DbUpdateException>(async Task () => await _productService.UpdateAsync(input_productDTO));
    }

}

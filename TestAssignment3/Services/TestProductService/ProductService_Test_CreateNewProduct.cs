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

namespace TestAssignment3.TestServices;

[TestFixture]
public class ProductSerice_Test_CreateNewProduct
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
    /// Scenario
    /// 1.Input new item
    /// 2.Input existing item
    /// 3.Input unsupported format of item
    /// </summary>

    //Run tung cai thi ok nhung run nhieu thi bi loi
    [Test]
    public async Task CreateNewProduct_InputIsNewItem_ReturnSuccessAsync()
    {
        //Arrage
        var input_productDTO = new ProductDTO()
        { 
            Id = Guid.NewGuid(), 
            Name = "Product 1", 
            Manufacture= "Lao Cai", 
            CategoryId = Guid.Parse("B3399EB3-ACD5-430E-B38A-D5993D01F03C")
        };

        var expected_createdProduct = input_productDTO;

        var result_createdProduct = await _productService.CreateAsync(input_productDTO);
        Assert.AreSame(expected_createdProduct, result_createdProduct, "can not create new product");
    }

    [Test]
    public async Task CreateNewProduct_InputIsExistingItem_AutoCreateNewId_ReturnTrue()
    {
        //Arrage
        var input_productDTO = _mapper.Map<ProductDTO>(await _context.Products.FirstOrDefaultAsync());

        var expected_createdProduct = new ProductDTO();
        expected_createdProduct.CopyFrom(input_productDTO);

        //Act
        var result_createdProduct = await _productService.CreateAsync(input_productDTO);
        
        //Assert
        Assert.AreNotEqual(expected_createdProduct.Id, result_createdProduct.Id, "can not create new id");
    }

    [Test]
    public async Task CreateNewProduct_InputIsLackFormatItem_ReturError()
    {
        //Arrage Lack of Name and Manufacture
        var input_productDTO = new ProductDTO()
        { 
            Id = Guid.NewGuid(),  
            CategoryId = Guid.Parse("B3399EB3-ACD5-430E-B38A-D5993D01F03C")
        };
        //Act
        // var result_createdProduct = await _productService.CreateAsync(input_productDTO);
        
        //Act/Assert
        Assert.ThrowsAsync<DbUpdateException>(async Task () => await _productService.CreateAsync(input_productDTO));
    }

}
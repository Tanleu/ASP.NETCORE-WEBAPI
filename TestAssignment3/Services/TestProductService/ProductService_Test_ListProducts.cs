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

public class ProductService_Test_ListProducts
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
    /// 1. Test all data match between DB and gathering from database
    /// </summary>
    [Test]
    public async Task ListAllProducts_Test_CheckDataBetweenDbContextAndServiceAsync()
    {
        //arrange
        var expected_numberOfProducts = _context.Products.Count();

        var result_listOfProducts = await _productService.ListAsync();

        Assert.AreEqual(expected_numberOfProducts, result_listOfProducts.Count(), "Lack of product return from service");
    }
}

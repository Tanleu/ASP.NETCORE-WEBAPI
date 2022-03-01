using Assignment_3_Product.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using AutoMapper;
using Assignment_3_Product.Profiles;
using System.Collections.Generic;
using Assignment_3_Product.Models;
using System;

namespace TestAssignment3.CommonConfig;

public class CommonConfig
{
    private static CommonConfig testConfig;
    public static CommonConfig GetCommonConfig()
    {
        if(testConfig is null) testConfig = new CommonConfig();
        return testConfig;
    }

    public ProductContext context;
    public IMapper mapper;
    private CommonConfig()
    {
        //Config database
        var contextOptions = new DbContextOptionsBuilder<ProductContext>()
            .UseInMemoryDatabase("BloggingControllerTest")
            .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;

        context = new ProductContext(contextOptions);

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        context.Categories.RemoveRange(context.Categories);
        context.Products.RemoveRange(context.Products);

        var createCategory = new CategoryDBModel(){ Id = Guid.NewGuid(), Name = "Điện thoại"};
        context.Categories.Add(createCategory);

        context.AddRange(
            new ProductDBModel { Id = Guid.NewGuid(), Name = "Samsung S20", Manufacture = "Korea", CategoryId = createCategory.Id },
            new ProductDBModel { Id = Guid.NewGuid(), Name = "Iphone 13 Pro Max", Manufacture = "Viet Nam", CategoryId = createCategory.Id}
        );

        context.SaveChanges();

        //Config mapper
        var mapperConfiguration = new MapperConfiguration(
            config => config.AddProfiles(new List<Profile>()
            {
                new ProductProfile(),
                new CategoryProfile()
            }));

        mapper = mapperConfiguration.CreateMapper();
    }
}

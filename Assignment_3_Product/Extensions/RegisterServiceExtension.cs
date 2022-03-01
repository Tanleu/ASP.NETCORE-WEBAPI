using Assignment_3_Product.Interfaces;
using Assignment_3_Product.Services;
using Assignment_3_Product.DataContexts;
using Microsoft.EntityFrameworkCore;
using Assignment_3_Product.Profiles;
using AutoMapper;

namespace Assignment_3_Product.Extensions;

public static class RegisterServiceExtension
{
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        //Inject Services
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<IProductService, ProductService>();
        
        //Inject DB context
        builder.Services.AddDbContext<ProductContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        //Inject Mapper
        builder.Services.AddAutoMapper(new []
        {
            typeof(ProductProfile),
            typeof(CategoryProfile)
        });
    }
}
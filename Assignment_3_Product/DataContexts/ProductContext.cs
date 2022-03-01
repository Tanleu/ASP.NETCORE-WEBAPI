using Microsoft.EntityFrameworkCore;
using Assignment_3_Product.Models;

namespace Assignment_3_Product.DataContexts;

public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }
    public DbSet<ProductDBModel> Products { get; set; }
    public DbSet<CategoryDBModel> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductDBModel>().ToTable("Product");
        modelBuilder.Entity<CategoryDBModel>().ToTable("Category");

        List<CategoryDBModel> listOfCategories = new List<CategoryDBModel>();
        listOfCategories.AddRange(
            new CategoryDBModel[]
            {
                new CategoryDBModel {Id = Guid.NewGuid(), Name = "Đồ điện"},
                new CategoryDBModel {Id = Guid.NewGuid(), Name = "Đồ cơ khí"},
                new CategoryDBModel {Id = Guid.NewGuid(), Name = "Đồ gia dụng"}
            }
        );

        modelBuilder.Entity<CategoryDBModel>().HasData(
            listOfCategories
        );

        modelBuilder.Entity<ProductDBModel>().HasData(
            new ProductDBModel { Id = Guid.NewGuid(), Name = "Điện thoại", Manufacture = "Hàn Quốc", CategoryId = listOfCategories[0].Id },
            new ProductDBModel { Id = Guid.NewGuid(), Name = "Tivi", Manufacture = "Trung Quốc", CategoryId = listOfCategories[0].Id },
            new ProductDBModel { Id = Guid.NewGuid(), Name = "Máy đục", Manufacture = "Việt Nam", CategoryId = listOfCategories[1].Id },
            new ProductDBModel { Id = Guid.NewGuid(), Name = "Máy khoan", Manufacture = "Mỹ", CategoryId = listOfCategories[1].Id },
            new ProductDBModel { Id = Guid.NewGuid(), Name = "Bếp từ", Manufacture = "Úc", CategoryId = listOfCategories[2].Id },
            new ProductDBModel { Id = Guid.NewGuid(), Name = "Nồi cơm", Manufacture = "Nga", CategoryId = listOfCategories[2].Id },
            new ProductDBModel { Id = Guid.NewGuid(), Name = "Máy giặt", Manufacture = "Campuchia", CategoryId = listOfCategories[2].Id },
            new ProductDBModel { Id = Guid.NewGuid(), Name = "Bàn Là", Manufacture = "Hàn Quốc", CategoryId = listOfCategories[2].Id }
        );
    }
}

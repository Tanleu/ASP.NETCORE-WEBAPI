namespace Assignment_3_Product.Models;

public class CategoryDBModel: IDisposable
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<ProductDBModel> Products { get; set; }

    public void Dispose()
    {
    }
}
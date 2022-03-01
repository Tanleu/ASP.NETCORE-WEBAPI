namespace Assignment_3_Product.Models;

public class ProductDBModel: IDisposable
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Manufacture { get; set; }
    public CategoryDBModel Category { get; set; }
    public Guid CategoryId { get; set; }

    public void Dispose() {}
}

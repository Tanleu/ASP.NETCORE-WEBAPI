namespace Assignment_3_Product.Models;

public class ProductDTO
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public string Manufacture { get; set; }
    public Guid CategoryId { get; set; }

    public void CopyFrom(ProductDTO product)
    {
        this.Id = product.Id;
        this.Name = product.Name;
        this.Manufacture = product.Manufacture;
        this.CategoryId = product.CategoryId;
    }
}